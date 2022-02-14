namespace BFGM.Classes
{
    public class ClassPathFile
    {
        protected ClassMain classMain;

        public ClassMain ClassMainInfo { get { return classMain; } }

        public ClassPathFile(ClassMain classMain)
        {
            this.classMain = classMain;
        }
    }
}
