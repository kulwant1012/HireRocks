using System;
using PS.ActivityVerification.PSServiceReference;
using PS.ActivityVerification.Messages;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.AspNet.SignalR.Client;
using System.Configuration;
using System.Collections.Generic;

namespace PS.ActivityVerification.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {     
        public RelayCommand LoginCommand { get; private set; }

        private User _user { get; set; }

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                RaisePropertyChanged(() => User);
            }
        }

        public LoginViewModel()
        {
            //KeywordDictionary keywordDictionary1 = new KeywordDictionary();
            //keywordDictionary1.DictionaryName = "WPF";
            //keywordDictionary1.Keywords = new string[]{
            //    "x:AsyncRecords",
            //    "x:Arguments",
            //    "x:Boolean",
            //    "x:Byte",
            //    "x:Char",
            //    "x:Class",
            //    "x:ClassAttributes",
            //    "x:ClassModifier",
            //    "x:Code",
            //    "x:ConnectionId",
            //    "x:Decimal",
            //    "x:Double",
            //    "x:FactoryMethod",
            //    "x:FieldModifier",
            //    "x:Int16",
            //    "x:Int32",
            //    "x:Int64",
            //    "x:Key",
            //    "x:Members",
            //    "x:Name",
            //    "x:Object",
            //    "x:Property",
            //    "x:Shared",
            //    "x:Single",
            //    "x:String",
            //    "x:Subclass",
            //    "x:SynchronousMode",
            //    "x:TimeSpan",
            //    "x:TypeArguments",
            //    "x:Uid",
            //    "x:Uri",
            //    "x:XData",

            //};


            //            keywordDictionary1.Keywords = new string[] { 
            //                "@CODEPAGE",
            //"@ENABLESESSIONSTATE",
            //"@LANGUAGE",
            //"@LCID",
            //"@TRANSACTION",
            //"Abandon",
            //"AddHeader",
            //"AppendToLog",
            //"Application",
            //"Application_OnEnd",
            //"Application_OnStart",
            //"ASPCode",
            //"ASPDescription",
            //"ASPError",
            //"BinaryRead",
            //"BinaryWrite",
            //"Buffer",
            //"CacheControl",
            //"Category",
            //"Charset",
            //"Clear",
            //"ClientCertificate",
            //"CodePage",
            //"CodePage",
            //"Column",
            //"Contents",
            //"ContentType",
            //"Cookies",
            //"CreateObject",
            //"Description",
            //"End",
            //"Execute",
            //"Expires",
            //"ExpiresAbsolute",
            //"File",
            //"Flush",
            //"Form",
            //"GetLastError",
            //"HTMLEncode",
            //"IsClientConnected",
            //"LCID",
            //"LCID",
            //"Line",
            //"Lock",
            //"MapPath",
            //"Number",
            //"ObjectContext",
            //"OnEndPage",
            //"OnStartPage",
            //"OnTransactionAbort",
            //"OnTransactionCommit",
            //"PICS",
            //"QueryString",
            //"Redirect",
            //"Remove",
            //"RemoveAll",
            //"Request",
            //"Response",
            //"ScriptTimeout",
            //"Server",
            //"ServerVariables",
            //"Session",
            //"Session_OnEnd",
            //"Session_OnStart",
            //"SessionID",
            //"SetAbort",
            //"SetComplete",
            //"Source",
            //"StaticObjects",
            //"StaticObjects",
            //"Status",
            //"Timeout",
            //"TotalBytes",
            //"Transfer",
            //"Unlock",
            //"URLEncode",
            //"Write",
            ////            };

            ////            keywordDictionary1.DictionaryName = "HTML 5";
            ////            keywordDictionary1.Keywords = new string[] {
            //            "<!--...-->",
            //"<!doctype>",
            //"<a>",
            //"<abbr>",
            //"<address>",
            //"<area>",
            //"<article>",
            //"<aside>",
            //"<audio>",
            //"<b>",
            //"<base>",
            //"<bb>",
            //"<bdi>",
            //"<bdo>",
            //"<blockquote>",
            //"<body>",
            //"<br>",
            //"<button>",
            //"<canvas>",
            //"<caption>",
            //"<cite>",
            //"<code>",
            //"<col>",
            //"<colgroup>",
            //"<data>",
            //"<datagrid>",
            //"<datalist>",
            //"<dd>",
            //"<del>",
            //"<details>",
            //"<dfn>",
            //"<dialog>",
            //"<div>",
            //"<dl>",
            //"<dt>",
            //"<em>",
            //"<embed>",
            //"<eventsource>",
            //"<fieldset>",
            //"<figcaption>",
            //"<figure>",
            //"<footer>",
            //"<form>",
            //"<h1>",
            //"<h2>",
            //"<h3>",
            //"<h4>",
            //"<h5>",
            //"<h6>",
            //"<head>",
            //"<header>",
            //"<hr>",
            //"<html>",
            //"<i>",
            //"<iframe>",
            //"<img>",
            //"<input>",
            //"<ins>",
            //"<kbd>",
            //"<keygen>",
            //"<label>",
            //"<legend>",
            //"<li>",
            //"<link>",
            //"<main>",
            //"<mark>",
            //"<map>",
            //"<menu>",
            //"<menuitem>",
            //"<meta>",
            //"<meter>",
            //"<nav>",
            //"<noscript>",
            //"<object>",
            //"<ol>",
            //"<optgroup>",
            //"<option>",
            //"<output>",
            //"<p>",
            //"<param>",
            //"<pre>",
            //"<progress>",
            //"<q>",
            //"<ruby>",
            //"<rp>",
            //"<rt>",
            //"<s>",
            //"<samp>",
            //"<script>",
            //"<section>",
            //"<select>",
            //"<small>",
            //"<source>",
            //"<span>",
            //"<strong>",
            //"<style>",
            //"<sub>",
            //"<summary>",
            //"<sup>",
            //"<table>",
            //"<tbody>",
            //"<td>",
            //"<textarea>",
            //"<tfoot>",
            //"<th>",
            //"<thead>",
            //"<time>",
            //"<title>",
            //"<tr>",
            //"<track>",
            //"<u>",
            //"<ul>",
            //"<var>",
            //"<video>",
            //"<wbr>"

            //            };
            //ActivityOptimizationSystemServiceClient.AddOrUpdateKeywordDictionary(keywordDictionary1);

            User = new User();
            LoginCommand = new RelayCommand(LoginCommandExecute);
        }

        private async void LoginCommandExecute()
        {
            try
            {
                if (!string.IsNullOrEmpty(User.Login) && !string.IsNullOrEmpty(User.Password))
                {
                    IsBusy = true;
                    var result =  await ActivityOptimizationSystemServiceClient.AOSSignInAsync(User.Login, User.Password);
                    if (!result.IsErrorReturned)
                    {
                        Dictionary<string, string> dictionary = new Dictionary<string, string>();
                        dictionary.Add("userId", result.Value.Id);
                        dictionary.Add("groupName", "ACS");
                        _hubConnection = new HubConnection(ConfigurationManager.AppSettings["NotificationServer"], dictionary);
                        _notificationHub = _hubConnection.CreateHubProxy("NotificaitonHub");
                        await _hubConnection.Start();

                        ErrorMessage = string.Empty;
                        Session.User = result.Value;
                        Messenger.Default.Send(new QSpaceMessage());
                        Messenger.Default.Send(new CloseLoginWindow());
                    }
                    else
                        ErrorMessage = result.ErrorMessage;
                    IsBusy = false;
                }

                if (string.IsNullOrEmpty(User.Login))
                {
                    ErrorMessage = "Enter login id";
                    return;
                }

                if (string.IsNullOrEmpty(User.Password))
                {
                    ErrorMessage = "Enter password";
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                ErrorMessage = ex.Message;
            }
        }
    }
}