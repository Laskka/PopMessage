namespace Laskka.Tools.PopMessage.Scripts
{
    public interface IPopMessage
    {
        public void Init();
        public void ToPool();
        public void Used(string text);
        public bool Move();
    
    }
}