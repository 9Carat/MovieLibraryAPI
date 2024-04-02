using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieLibraryAPI.Models;
using MovieLibraryAPI.Models.DTO;
using MovieLibraryAPI.Repository.IRepository;
using System.Net;

namespace MovieLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieRepository _context;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public MovieController(IMovieRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _response = new();
        }
        [HttpGet("movieId/{movieId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetByMovieId(Guid movieId)
        {
            try
            {
                var movie = await _context.GetByMovieIdAsync(m => m.Id == movieId);
                if (movie == null)
                {
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<MovieDTO>(movie);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }
        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetByUserId(string userId)
        {
            try
            {
                IEnumerable<Movie> movies = await _context.GetByUserIdAsync(m => m.Fk_UserId == userId);
                if (movies == null || !movies.Any()) 
                { 
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<List<MovieDTO>>(movies);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> AddMovie([FromBody]MovieCreateDTO movieCreateDTO)
        {
            try
            {
                //Check if movie has already been added
                if (await _context.GetByMovieIdAsync(m => m.Title == movieCreateDTO.Title) != null)
                {
                    ModelState.AddModelError("Error", "Movie already added to watchlist");
                    return BadRequest(ModelState);
                }
                if (movieCreateDTO == null)
                {
                    return BadRequest(movieCreateDTO);
                }
                Movie movie = _mapper.Map<Movie>(movieCreateDTO);
                await _context.AddMovieAsync(movie);

                foreach (var ratingDTO in movieCreateDTO.Ratings)
                {
                    var rating = _mapper.Map<Rating>(ratingDTO);
                    rating.Fk_MovieId = movieCreateDTO.Id;
                    await _context.AddRatingAsync(rating);
                }

                if (movieCreateDTO.StreamingServices != null)
                {
                    foreach (var streamingServiceDTO in movieCreateDTO.StreamingServices)
                    {
                        var streamingService = _mapper.Map<StreamingService>(streamingServiceDTO);
                        streamingService.Fk_MovieId = movieCreateDTO.Id;
                        await _context.AddStreamingServiceAsync(streamingService);
                    }
                }

                _response.Result = _mapper.Map<MovieCreateDTO>(movie);
                _response.StatusCode = HttpStatusCode.OK;
                return CreatedAtAction(nameof(AddMovie), new {movie.Id}, _response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.ToString() };
            }
            return _response;
        }

        [HttpDelete("{movieId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteMovie(Guid movieId)
        {
            try
            {
                var movie = await _context.GetByMovieIdAsync(m => m.Id == movieId);
                if (movie == null)
                {
                    return NotFound();
                }
                await _context.RemoveAsync(movie);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception e) 
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }
    }
}
