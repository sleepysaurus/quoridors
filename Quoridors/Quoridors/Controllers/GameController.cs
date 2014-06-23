using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Quoridors.Models;
using Newtonsoft.Json;
using System.Net;

namespace Quoridors.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        public JsonResult NewGame()
        {
            var player1 = new Player(1, "John");
            var player2 = new Player(2, "Samantha");
            var players = new Player[]
            {
                player1,
                player2
            };
            return Json(players, JsonRequestBehavior.AllowGet);
        }

        public bool MovePlayer(Move move)
        {
            return true;
        }

        public bool PlaceWall(Wall wall)
        {
            return true;
        }
    }
}