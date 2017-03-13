namespace Excepions
{
    using System;
    
    class GameOver : Exception
    {
        public GameOver()
            : base()
        {
        }

        public GameOver(string message)
            : base(message)
        {

        }
    }
}
