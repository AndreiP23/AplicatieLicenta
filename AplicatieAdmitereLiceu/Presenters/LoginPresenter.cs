using LicentaNou2.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Presenters
{
    public class LoginPresenter
    {
        private ILoginView _iLoginView;

        public void SetView(ILoginView view)
        {
            _iLoginView = view;
        }

    }
}
