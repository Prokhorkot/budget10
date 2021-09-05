using System;

namespace GAIExam.MVVM.Model
{
    class FileNotFoundException : Exception
    {
        public FileNotFoundException(String msg) : base(msg)
        {

        }
    }
}
