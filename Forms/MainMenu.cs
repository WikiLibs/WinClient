﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinClient.Views;

namespace WinClient.Forms
{
    public partial class MainMenu : Form
    {
        private NetManager _netManager = new NetManager();
        private static List<Views.View.IBuilder> ViewList = new List<Views.View.IBuilder>()
        {
            new DebugInfo.Builder(),
            new Browsers.ApiKeyBrowser.Builder(),
            new Browsers.GroupBrowser.Builder(),
            new Browsers.BotBrowser.Builder(),
            new Browsers.SymbolLangBrowser.Builder(),
            new Browsers.SymbolTypeBrowser.Builder(),
            new SymbolViewer.Builder(),
            new UserViewer.Builder()
        };
        private Views.View _current;

        public MainMenu()
        {
            InitializeComponent();
            foreach (Views.View.IBuilder v in ViewList)
            {
                ActionList.Items.Add(v.DisplayName);
            }
        }

        private void InputLogin_Click(object sender, EventArgs e)
        {
            IOPanel.Controls.Clear();
            _netManager = new NetManager(InputUserName.Text, InputPassword.Text);
            if (_netManager.GetAuthError() != null)
            {
                var bx = new TextBox();
                bx.Font = new System.Drawing.Font("Microsoft Sans Serif", 14);
                bx.Multiline = true;
                bx.Dock = DockStyle.Fill;
                bx.Text = JsonConvert.SerializeObject(_netManager.GetAuthError(), Formatting.Indented);
                IOPanel.Controls.Add(bx);
            }
            else
                LoginPanel.Visible = false;
            dynamic rsp;
            _netManager.Put(true, "symbol/C/InputStream1/sfInputStream", out rsp, JObject.FromObject(new
            {
                lang = "C",
                path = "C/InputStream1/sfInputStream",
                type = "typedef",
                prototypes = new object[]
                {
                        new
                        {
                            prototype = "typedef sfInputStream struct sfInputStream",
                            parameters = new object[] { }
                        }
                },
                symbols = new string[] { }
            }));
            _netManager.Put(true, "symbol/C/InputStream1/sfInputStream", out rsp, JObject.FromObject(new
            {
                lang = "C",
                path = "C/InputStream1/sfInputStream",
                type = "struct",
                prototypes = new object[]
                {
                        new
                        {
                            prototype = "struct sfInputStream",
                            parameters = new object[] { }
                        }
                },
                symbols = new string[] {
                        "C/InputStream1/sfInputStream/read",
                        "C/InputStream1/sfInputStream/seek",
                        "C/InputStream1/sfInputStream/tell",
                        "C/InputStream1/sfInputStream/getSize",
                        "C/InputStream1/sfInputStream/userData"
                    }
            }));
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            _netManager.Exit();
        }

        /*private void RunRequest(IAction act, Control input)
        {
            string url = act.GetURL(input);
            dynamic res = null;
            bool success = false;
            if (act.Method == "GET")
                success = _netManager.Get(act.NeedAuth, url, out res);
            else if (act.Method == "POST")
                success = _netManager.Post(act.NeedAuth, url, out res, act.GetInput(input));
            else if (act.Method == "PATCH")
                success = _netManager.Patch(act.NeedAuth, url, out res, act.GetInput(input));
            else if (act.Method == "DELETE")
                success = _netManager.Delete(act.NeedAuth, url, out res);
            IOPanel.Controls.Clear();
            if (!success)
            {
                TextBox bx = new TextBox();
                bx.Multiline = true;
                bx.Text = JsonConvert.SerializeObject(res, Formatting.Indented);
                IOPanel.Controls.Add(bx);
            }
            else
            {
                Control c = _current.CreateOutputControl();
                c.Dock = DockStyle.Fill;
                IOPanel.Controls.Add(c);
                _current.ProcessOutput(c, res, _netManager);
            }
            _current = null;
            InputRun.Visible = false;
        }*/

        private void ActionList_Click(object sender, EventArgs e)
        {
            IOPanel.Controls.Clear();
            if (ActionList.SelectedItem != null)
            {
                Views.View.IBuilder view = null;
                foreach (Views.View.IBuilder v in ViewList)
                {
                    if (v.DisplayName == (string)ActionList.SelectedItem)
                        view = v;
                }
                _current = view.Build(_netManager);
                Control c = _current.BuildMainView();
                if (c != null)
                {
                    c.Dock = DockStyle.Fill;
                    IOPanel.Controls.Add(c);
                }
            }
        }
    }
}
