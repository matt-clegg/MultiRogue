using MultiRogue.Core.Actions;

namespace MultiRogue.Core.Turns
{
    public interface ITurnable
    {
        bool CanTakeTurn();
        bool IsWaitingForInput();
        bool GainEnergy();
        void FinishTurn();

        BaseAction GetAction();
    }
}
