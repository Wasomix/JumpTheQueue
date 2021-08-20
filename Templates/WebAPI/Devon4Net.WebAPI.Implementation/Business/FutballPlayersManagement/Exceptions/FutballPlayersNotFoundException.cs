using Devon4Net.Infrastructure.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devon4Net.WebAPI.Implementation.Business.FutballPlayersManagement.Exceptions
{
    /// <summary>
    /// Custom exception FutballPlayersNotFoundException
    /// </summary>
    [Serializable]
    public class FutballPlayersNotFoundException : Exception, IWebApiException
    {
        /// <summary>
        /// The forced http status code to be fired on the exception manager
        /// </summary>
        public int StatusCode => StatusCodes.Status500InternalServerError;

        /// <summary>
        /// Show the message on the response?
        /// </summary>
        public bool ShowMessage => true;

        /// <summary>
        /// Initializes a new instance of the <see cref="FutballPlayersNotFoundException"/> class.
        /// </summary>
        public FutballPlayersNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FutballPlayersNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public FutballPlayersNotFoundException(string message)
            : base(message)
        {
        }
    }
}
