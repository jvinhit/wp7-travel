using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Main_Service.Messages;
using Data_Objects;
using Main_Service.MessageBase;
using System.Web.Security;
using System.ServiceModel;
using Main_Service.DataMapper;
using Business_Objects;

namespace Main_Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class MainService : IMainService
    {
        // Session state variables
        private string _accessToken;
        private string _userName;
        // Create static data access objects
        private static readonly IMapImage _mapImage = DataAccess.MapImage;

     
        private bool ValidRequest(RequestBase request, ResponseBase response, Validate validate)
        {
            // Validate Client Tag. 
            // Hardcoded here. In production this should query a 'client' table in a database.
            if ((Validate.ClientTag & validate) == Validate.ClientTag)
            {
                if (request.ClientTag != "ABC123")
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Unknown Client Tag";
                    return false;
                }
            }


            // Validate access token
            if ((Validate.AccessToken & validate) == Validate.AccessToken)
            {
                if (request.AccessToken != _accessToken)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Invalid or expired AccessToken. Call GetToken()";
                    return false;
                }
            }

            // Validate user credentials
            if ((Validate.UserCredentials & validate) == Validate.UserCredentials)
            {
                if (_userName == null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Please login and provide user credentials before accessing these methods.";
                    return false;
                }
            }


            return true;
        }

        [Flags]
        private enum Validate
        {
            ClientTag = 0x0001,
            AccessToken = 0x0002,
            UserCredentials = 0x0004,
            All = ClientTag | AccessToken | UserCredentials
        }


        public TokenResponse GetToken(TokenRequest request)
        {
            var response = new TokenResponse(request.RequestId);

            // Validate client tag only
            if (!ValidRequest(request, response, Validate.ClientTag))
                return response;

            // Note: these are session based and expire when session expires.
            _accessToken = Guid.NewGuid().ToString();


            response.AccessToken = _accessToken;
            return response;
        }

        public LoginResponse Login(LoginRequest request)
        {
            var response = new LoginResponse(request.RequestId);

            // Validate client tag and access token
            if (!ValidRequest(request, response, Validate.ClientTag | Validate.AccessToken))
                return response;

            if (!Membership.ValidateUser(request.UserName, request.Password))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = "Invalid username and/or password.";
                return response;
            }

            _userName = request.UserName;

            return response;
        }

        public LogoutResponse Logout(LogoutRequest request)
        {
            var response = new LogoutResponse(request.RequestId);

            // Validate client tag and access token
            //if (!ValidRequest(request, response, Validate.ClientTag | Validate.AccessToken))
            //    return response;

            _userName = null;

            return response;
        }

        public MapImageResponse GetMapGoogle(MapImageRequest request)
        {
            var response = new MapImageResponse(request.RequestId);

            response.mapImageDTO = Mapper.ToObjectDTOTranfer((MapImage)_mapImage.GetMapImages(request.mapImageDTO.Latitude,
                                                                          request.mapImageDTO.Longitude,
                                                                          request.mapImageDTO.Zoom,
                                                                          request.mapImageDTO.Size,
                                                                          request.mapImageDTO.GetMaker));
            return response;


        }
    }
}
