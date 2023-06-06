using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Services;

namespace WorldCup.View
{
    public class AddGameView
    {
        public void Submit()
        {
            AddGameDto dto = null; // Probably get this from a user or from a third party service
            GameService.AddGame(dto);

            //....

        }
    }
}
