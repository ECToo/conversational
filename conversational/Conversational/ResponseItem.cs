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
    public class ConversationalResponseItem
    {
        private int _toWhatConversation;
        private string _response;

        public ConversationalResponseItem(int to, string response)
        {
            this._toWhatConversation = to;
            this._response = response;
        }

        public override string ToString()
        {
            return _response;
        }

        public int To
        {
            get { return _toWhatConversation; }
            set { _toWhatConversation = value; }
        }

        public string Response
        {
            get { return _response; }
            set { _response = value; }
        }
    }
}
