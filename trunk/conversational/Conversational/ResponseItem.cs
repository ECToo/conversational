///////////////////////////////////////////////////////////////////////
// Conversational Library //////////////////// Conversational Config //
/////////////////// 2008  Magrathean Technologies /////////////////////
///////////////////////////////////////////////////////////////////////
//                                                                   //
// This program is free software; you can redistribute it and/or     //
// modify it under the terms of the GNU General Public License       //
// as published by the Free Software Foundation; either version 2    //
// of the License, or any later version.                             //
//                                                                   //
// This program is distributed in the hope that it will be useful,   //
// but WITHOUT ANY WARRANTY; without even the implied warranty of    // 
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the     //
// GNU General Public License for more details.                      //
//                                                                   //
// You should have received a copy of the GNU General Public License //
// along with this program; if not, write to the                     //
// Free Software Foundation, Inc.,                                   //
// 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.     //
//                                                                   //
//// Released under the GPL /////////////////// August 15th, 2008 /////
///////////////////////////////////////////////////////////////////////
////////////////////////////// Coded by: Fox Diller ///////////////////
///////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;

namespace ConversationalAPI
{
    /// <summary>
    /// A class to define a single reponse to a multi choice response conversation
    /// </summary>
    public class ConversationalResponseItem
    {
        private int _toWhatConversation;
        private string _response;

        /// <summary>
        /// ConversationalResponseItem Constructor
        /// </summary>
        /// <param name="to">The ConversationalItem ID of the response choice</param>
        /// <param name="response">The response to display to the user</param>
        public ConversationalResponseItem(int to, string response)
        {
            this._toWhatConversation = to;
            this._response = response;
        }

        /// <summary>
        /// Overrode from Object; during debug the string will be displayed with the ID that would lead
        /// from the selection of that response
        /// </summary>
        /// <returns>The string response</returns>
        public override string ToString()
        {
#if DEBUG
            return _response + " -> " + _toWhatConversation.ToString();
#else
            return _response;
#endif
        }

        /// <summary>
        /// The id a ConversationalItem if this choice is selected
        /// </summary>
        public int To
        {
            get { return _toWhatConversation; }
            set { _toWhatConversation = value; }
        }

        /// <summary>
        /// The string response of this ConversationResponseItem
        /// </summary>
        public string Response
        {
            get { return _response; }
            set { _response = value; }
        }
    }
}
