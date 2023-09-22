namespace CodeBase.UI.Overlays
{
    public interface IAwaitingOverlay
    {
        void Show(string withMessage);
        void Hide();
    }
}