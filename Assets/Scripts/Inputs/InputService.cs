using System;
using Services.Inputs;

namespace Inputs
{
    public class InputService : IInputService
    {
         private readonly MapInputs _input = new ();

         public void OnShoot(Action cast) =>
             _input.Tank.Shoot.performed += _ =>
                 cast?.Invoke();

         public void OffShoot(Action offCast) =>
             _input.Tank.Shoot.canceled += _ =>
                 offCast?.Invoke();

         public void OnActiveControls() =>
             _input.Tank.Enable();

         public void InActiveControls() =>
             _input.Tank.Disable();
    }
}