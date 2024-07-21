using Microsoft.AspNetCore.Mvc;
using Benito.Datos;
public class BenitoControllerBase<T> : ControllerBase where T : class {

        private readonly IBenitoBaseRepository<T> _benitoBaseRepository;
        public BenitoControllerBase(IBenitoBaseRepository<T> benitoBaseRepository)
        {
            _benitoBaseRepository = benitoBaseRepository;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] T item)
        {
            return HandleResult(async () =>
            {
                return await _benitoBaseRepository.AddAsync(item);
            });
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(Guid id)
        {
            return HandleResult(async () =>
            {
                var result = await _benitoBaseRepository.Get(id);
                return result;
            });
        }

        [HttpGet("list")]
        public IActionResult GetAll()
        {
            return HandleResult(async () =>
            {
                var result = await _benitoBaseRepository.GetAllAsync();
                return result;
            });
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] T item)
        {
            return HandleResult(async () =>
            {
                return await _benitoBaseRepository.Update(item);
            });
        }  

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return HandleResult(async () =>
            {
                return await _benitoBaseRepository.Delete(id);
            });
        }

        private IActionResult HandleResult<T>(Func<Task<T>> action)
        {
            try
            {
                var result = action().Result;
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

}