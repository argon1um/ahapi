using AHRestAPI.Models;
using AnimalHouseRestAPI.DataBase;
using AnimalHouseRestAPI.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AHRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsC : ControllerBase
    {
        JsonSerializerSettings mainSettings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
        [HttpGet]
        [Route("/getAnimalTypes")]
        public ActionResult<Animaltype> GetListOfTypes()
        {
            List<Animaltype> animaltypes = new List<Animaltype>();
            animaltypes = DataBaseConnection.Context.Animaltypes.ToList();
            return Ok(animaltypes);
        }

        [HttpGet]
        [Route("/getCatBreeds")]

        public ActionResult<Animalbreed> GetCatBreeds()
        {
            List<Animalbreed> catList = new List<Animalbreed>();
            catList = DataBaseConnection.Context.Animalbreeds.ToList().Where(x => x.AnimalTypeid == 1).ToList();
            return Ok(catList);
        }

        [HttpGet]
        [Route("/getDogBreeds")]

        public ActionResult<Animalbreed> GetDogBreeds()
        { 
            List<Animalbreed> dogList = new List<Animalbreed>();
            dogList = DataBaseConnection.Context.Animalbreeds.ToList().Where(x => x.AnimalTypeid == 2).ToList();
            return Ok(dogList);
        }

        [HttpGet]
        [Route("/getAllBreeds")]

        public ActionResult<Animalbreed> GetAllBreeds()
        {
            List<Animalbreed> allBreeds = new List<Animalbreed>();
            allBreeds = DataBaseConnection.Context.Animalbreeds.ToList();
            return Ok(allBreeds);
        }
    }
}
