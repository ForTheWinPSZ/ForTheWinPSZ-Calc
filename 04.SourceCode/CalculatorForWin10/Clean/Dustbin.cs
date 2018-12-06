using System;

using System.Collections.Generic;

using System.Text;
namespace Clean

{

    public class Dustbin

    {

        private List<string> list;



        public Dustbin(List<string> list)

        {

            this.list = list;

        }



        public List<string> Clear()

        {

            list.Clear();

            return list;

        }

    }

}