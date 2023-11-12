using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeightL
{
   public class CloudParam
    {
        public int h;
        public int w;
        public Bitmap picture;
        public int speed;
        public int dir;
    }
    public class ParamBigCloud : CloudParam
    {
        public ParamBigCloud(){
            picture = new Bitmap(@"D:\Images\BigCloud.png");
            h = 60;
            w = 70;
            dir = 1;
            speed = 2;
        }
    }
    public class ParamMediumCloud : CloudParam
    {
        public ParamMediumCloud()
        {
            picture = new Bitmap(@"D:\Images\MediumCloud.png");
            h = 30;
            w = 60;
            dir = 1;
            speed = 4;
        }
    }
    public class ParamSmallCloud : CloudParam
    {
        public ParamSmallCloud()
        {
            picture = new Bitmap(@"D:\Images\SmallCloud.png");
            h = 20;
            w = 40;
            dir = 1;
            speed = 6;
        }
    }
    public class Cloud {
        public int x;
        public int y;
        public Random rand;
        public int y0;
        public int[] ways;
        public int dir;
        public int speed;
        public CloudParam param;

        public Cloud(int y0, CloudParam param, Random r, int[] w){
            this.y0 = y0;
            this.dir = 1;
            this.param = param;
            this.rand = r;
            this.x = r.Next(0, 450);
            this.ways = w;
            this.speed = param.speed;
        }
        public void respawn()
        {

            if (x > 850)
            {

                x = rand.Next(800, 835);
                y0 = ways[rand.Next(0, ways.Length)];
                dir *= -1;
            }
            else if (-50 > x) {
                x = rand.Next(-50, 0);
                y0 = ways[rand.Next(0, ways.Length)];
                dir *= -1;
            }
            x += dir * speed;
            y = y0;
        }
    }
}
