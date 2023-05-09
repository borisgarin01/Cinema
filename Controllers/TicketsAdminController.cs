using Cinema.Models.Tickets;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    public class TicketsAdminController : Controller
    {
        private readonly string pathToJson="/Files/Tickets.json";

        public ActionResult SaveTickets()
        {
            var movies = new Movie[]
            {
                new Movie
                {
                    Id=1,
                    Name="Дэдпул 2",
                    Description="Единственный и неповторимый болтливый наемник – вернулся! Еще более масштабный, еще более разрушительный и даже еще более голозадый, чем прежде! Когда в его жизнь врывается суперсолдат с убийственной миссией, Дэдпул вынужден задуматься о дружбе, семье и о том, что на самом деле значит быть героем, попутно надирая 50 оттенков задниц. Потому что иногда чтобы делать хорошие вещи, нужно использовать грязные приемчики.",
                    Duration=110,
                    Genres=new Genre[] {Genre.Action, Genre.Comedy},
                    Types=new[]{ Models.Tickets.Type.D2},
                    MinAge=18,
                    Rating=4.33f,
                    ImageUrl="https://images.kinomax.ru/550/films/3/3781/p_6f4c81e.jpg",

                },
                new Movie
                {
                    Id=2,
                    Name="Дэдпул",
                    Description="Уэйд Уилсон — наёмник. Будучи побочным продуктом программы вооружённых сил под названием «Оружие X», Уилсон приобрёл невероятную силу, проворство и способность к исцелению. Но страшной ценой: его клеточная структура постоянно меняется, а здравомыслие сомнительно. Всё, чего Уилсон хочет, — это держаться на плаву в социальной выгребной яме. Но течение в ней слишком быстрое.",
                    Duration=104,
                    Genres=new Genre[] {Genre.Action, Genre.Comedy},
                    Types=new[]{ Models.Tickets.Type.D2},
                    MinAge=18,
                    Rating= 4.5f,
                    ImageUrl="https://images.kinomax.ru/550/films/2/2762/p_441f0b6.jpg"
                }
            };

            var tariffs = new Tariff[]
            {
                new Tariff
                {
                    Id=1,
                    Name="Standard",
                    Cost=220
                },
                new Tariff
                {
                    Id=2,
                    Name="DBox",
                    Cost=440
                }
            };

            var halls = new Hall[]
            {
                new Hall
                {
                    Id=1,
                    Name="Hall 1"
                },
                new Hall
                {
                    Id=2,
                    Name="Hall 2"
                }
            };

            var timeslots = new Timeslot[]
            {
                new Timeslot
                {
                    Id=1,
                    HallId=1,
                    MovieId=1,
                    StartTime=DateTime.Now.AddHours(-1),
                    TariffId=1
                },
                new Timeslot
                {
                    Id=2,
                    HallId=1,
                    MovieId=1,
                    StartTime=DateTime.Now,
                    TariffId=1
                },
                new Timeslot
                {
                    Id=3,
                    HallId=1,
                    MovieId=1,
                    StartTime=DateTime.Now.AddHours(1),
                    TariffId=2
                },
                new Timeslot
                {
                    Id=4,
                    HallId=2,
                    MovieId=2,
                    StartTime=DateTime.Now.AddHours(-1),
                    TariffId=1
                },
                new Timeslot
                {
                    Id=5,
                    HallId=2,
                    MovieId=2,
                    StartTime=DateTime.Now,
                    TariffId=1
                },
                new Timeslot
                {
                    Id=6,
                    HallId=2,
                    MovieId=1,
                    StartTime=DateTime.Now.AddHours(1),
                    TariffId=2
                },
            };

            var jsonModel = new TicketsJsonModel
            {
                Halls = halls,
                Movies = movies,
                Tariffs = tariffs,
                Timeslots = timeslots
            };

            var json = JsonConvert.SerializeObject(jsonModel);
            var jsonFilePath = HttpContext.Server.MapPath(pathToJson);
            System.IO.File.WriteAllText(jsonFilePath, json);

            return Content(json, "application/json");
        }

        public ActionResult GetAllTickets()
        {
            var jsonFilePath = HttpContext.Server.MapPath(pathToJson);
            if (System.IO.File.Exists(jsonFilePath))
            {
                var jsonModel = System.IO.File.ReadAllText(jsonFilePath);
                var deserializedModel = JsonConvert.DeserializeObject<TicketsJsonModel>(jsonModel);
                return Content(jsonModel, "application/json");
            }
            return Content("File don't exists", "application/json");
        } 
    }
}