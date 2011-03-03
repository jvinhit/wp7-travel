﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Main_Service.Messages;

namespace Main_Service
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IMainService
    {
        [OperationContract]
        TokenResponse GetToken(TokenRequest request);

        [OperationContract]
        LoginResponse Login(LoginRequest request);

        [OperationContract]
        LogoutResponse Logout(LogoutRequest request);
    }
}