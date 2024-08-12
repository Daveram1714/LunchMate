using Domain.Entities;
using Domain.UseCase.Mel_usecase;
using Microsoft.AspNetCore.Mvc;

namespace LunchMate_updated.Controllers
{

        [ApiController]
        [Route("")]

        public class MealController : ControllerBase
        {
            private readonly CreatMeal _createMeal;
            private readonly UpdateMeal _updateMeal;
            private readonly DeleteMeal _deleteMeal;
            private readonly GetMeal _getMeal;
            private readonly GetAllmeals _getAllmeals;
              
            public MealController(GetAllmeals getAllmeals,CreatMeal createMeal, UpdateMeal updateMeal, DeleteMeal deleteMeal, GetMeal getMeal)
            {
                _createMeal = createMeal;
                _updateMeal = updateMeal;
                _deleteMeal = deleteMeal;
                _getMeal = getMeal;
                _getAllmeals = getAllmeals;
            }

            [HttpPost]
            public async Task<IActionResult> CreateMael(Meal meal )
            {
                await _createMeal.ExecuteAsync(meal);
                return Ok(meal);
            }
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var meals = await _getAllmeals.ExecuteAsync();
                return Ok(meals);
            }


            [HttpGet("{id}")]
            public async Task<IActionResult>GetMeal(int id)
            {
                await _getMeal.ExecuteAsync(id);
                return Ok();
            }

            [HttpPost ("{id}")]
            public async Task<IActionResult> UpdateMeal(int id,Meal meal)
            {
                if (meal == null) return NotFound();
                await _updateMeal.ExecuteAsync(meal);
                return Ok();
            }
            [HttpDelete]
            public async Task<IActionResult> DeleteMeal(int id)
            {
                await _deleteMeal.ExecuteAsync(id);
                return Ok();    
                
            }
        }
    }

