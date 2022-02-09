using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders.Players
{
    public class Players
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int[] Pos { get; set; }
        public BadImageFormatException Image { get; set; }
        public void Romanza(string name, BadImageFormatException image)
        {
            this.Name = name;
            this.Image = image;
        }
        private void SetPosition(int column, int row)
        {
            Pos[0] = column;
            Pos[1] = row;
        }
        private void ResetPosition()
        {
            Pos[0] = 0;
            Pos[1] = 0;
        }
    }
}
