using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXAutomation
{
    public static class Messages
    {
        public static readonly uint WM_NULL = 0x0000;
        public static readonly uint WM_CREATE = 0x0001;
        public static readonly uint WM_DESTROY = 0x0002;
        public static readonly uint WM_MOVE = 0x0003;
        public static readonly uint WM_SIZE = 0x0005;

        public static readonly uint WM_ACTIVATE = 0x0006;

        public static readonly uint WM_SETFOCUS = 0x0007;
        public static readonly uint WM_KILLFOCUS = 0x0008;
        public static readonly uint WM_ENABLE = 0x000A;
        public static readonly uint WM_SETREDRAW = 0x000B;
        public static readonly uint WM_SETTEXT = 0x000C;
        public static readonly uint WM_GETTEXT = 0x000D;
        public static readonly uint WM_GETTEXTLENGTH = 0x000E;
        public static readonly uint WM_PAINT = 0x000F;
        public static readonly uint WM_CLOSE = 0x0010;

        public static readonly uint WM_QUERYENDSESSION = 0x0011;
        public static readonly uint WM_QUERYOPEN = 0x0013;
        public static readonly uint WM_ENDSESSION = 0x0016;

        public static readonly uint WM_QUIT = 0x0012;
        public static readonly uint WM_ERASEBKGND = 0x0014;
        public static readonly uint WM_SYSCOLORCHANGE = 0x0015;
        public static readonly uint WM_SHOWWINDOW = 0x0018;

        public static readonly uint WM_SETTINGCHANGE = 0x001A;

        public static readonly uint WM_DEVMODECHANGE = 0x001B;
        public static readonly uint WM_ACTIVATEAPP = 0x001C;
        public static readonly uint WM_FONTCHANGE = 0x001D;
        public static readonly uint WM_TIMECHANGE = 0x001E;
        public static readonly uint WM_CANCELMODE = 0x001F;
        public static readonly uint WM_SETCURSOR = 0x0020;
        public static readonly uint WM_MOUSEACTIVATE = 0x0021;
        public static readonly uint WM_CHILDACTIVATE = 0x0022;
        public static readonly uint WM_QUEUESYNC = 0x0023;

        public static readonly uint WM_GETMINMAXINFO = 0x0024;

        public static readonly uint WM_PAINTICON = 0x0026;
        public static readonly uint WM_ICONERASEBKGND = 0x0027;
        public static readonly uint WM_NEXTDLGCTL = 0x0028;
        public static readonly uint WM_SPOOLERSTATUS = 0x002A;
        public static readonly uint WM_DRAWITEM = 0x002B;
        public static readonly uint WM_MEASUREITEM = 0x002C;
        public static readonly uint WM_DELETEITEM = 0x002D;
        public static readonly uint WM_VKEYTOITEM = 0x002E;
        public static readonly uint WM_CHARTOITEM = 0x002F;
        public static readonly uint WM_SETFONT = 0x0030;
        public static readonly uint WM_GETFONT = 0x0031;
        public static readonly uint WM_SETHOTKEY = 0x0032;
        public static readonly uint WM_GETHOTKEY = 0x0033;
        public static readonly uint WM_QUERYDRAGICON = 0x0037;
        public static readonly uint WM_COMPAREITEM = 0x0039;

        public static readonly uint WM_GETOBJECT = 0x003D;

        public static readonly uint WM_COMPACTING = 0x0041;
        public static readonly uint WM_COMMNOTIFY = 0x0044;
        public static readonly uint WM_WINDOWPOSCHANGING = 0x0046;
        public static readonly uint WM_WINDOWPOSCHANGED = 0x0047;

        public static readonly uint WM_POWER = 0x0048;

        public static readonly uint WM_COPYDATA = 0x004A;
        public static readonly uint WM_CANCELJOURNAL = 0x004B;

        public static readonly uint WM_NOTIFY = 0x004E;
        public static readonly uint WM_INPUTLANGCHANGEREQUEST = 0x0050;
        public static readonly uint WM_INPUTLANGCHANGE = 0x0051;
        public static readonly uint WM_TCARD = 0x0052;
        public static readonly uint WM_HELP = 0x0053;
        public static readonly uint WM_USERCHANGED = 0x0054;
        public static readonly uint WM_NOTIFYFORMAT = 0x0055;

        public static readonly uint WM_CONTEXTMENU = 0x007B;
        public static readonly uint WM_STYLECHANGING = 0x007C;
        public static readonly uint WM_STYLECHANGED = 0x007D;
        public static readonly uint WM_DISPLAYCHANGE = 0x007E;
        public static readonly uint WM_GETICON = 0x007F;
        public static readonly uint WM_SETICON = 0x0080;

        public static readonly uint WM_NCCREATE = 0x0081;
        public static readonly uint WM_NCDESTROY = 0x0082;
        public static readonly uint WM_NCCALCSIZE = 0x0083;
        public static readonly uint WM_NCHITTEST = 0x0084;
        public static readonly uint WM_NCPAINT = 0x0085;
        public static readonly uint WM_NCACTIVATE = 0x0086;
        public static readonly uint WM_GETDLGCODE = 0x0087;

        public static readonly uint WM_SYNCPAINT = 0x0088;

        public static readonly uint WM_NCMOUSEMOVE = 0x00A0;
        public static readonly uint WM_NCLBUTTONDOWN = 0x00A1;
        public static readonly uint WM_NCLBUTTONUP = 0x00A2;
        public static readonly uint WM_NCLBUTTONDBLCLK = 0x00A3;
        public static readonly uint WM_NCRBUTTONDOWN = 0x00A4;
        public static readonly uint WM_NCRBUTTONUP = 0x00A5;
        public static readonly uint WM_NCRBUTTONDBLCLK = 0x00A6;
        public static readonly uint WM_NCMBUTTONDOWN = 0x00A7;
        public static readonly uint WM_NCMBUTTONUP = 0x00A8;
        public static readonly uint WM_NCMBUTTONDBLCLK = 0x00A9;


        public static readonly uint WM_NCXBUTTONDOWN = 0x00AB;
        public static readonly uint WM_NCXBUTTONUP = 0x00AC;
        public static readonly uint WM_NCXBUTTONDBLCLK = 0x00AD;

        public static readonly uint WM_INPUT_DEVICE_CHANGE = 0x00FE;

        public static readonly uint WM_INPUT = 0x00FF;

        public static readonly uint WM_KEYFIRST = 0x0100;
        public static readonly uint WM_KEYDOWN = 0x0100;
        public static readonly uint WM_KEYUP = 0x0101;
        public static readonly uint WM_CHAR = 0x0102;
        public static readonly uint WM_DEADCHAR = 0x0103;
        public static readonly uint WM_SYSKEYDOWN = 0x0104;
        public static readonly uint WM_SYSKEYUP = 0x0105;
        public static readonly uint WM_SYSCHAR = 0x0106;
        public static readonly uint WM_SYSDEADCHAR = 0x0107;

        public static readonly uint WM_UNICHAR = 0x0109;
        public static readonly uint WM_KEYLAST = 0x0109;

        //public static readonly uint WM_KEYLAST = 0x0108;

        public static readonly uint WM_IME_STARTCOMPOSITION = 0x010D;
        public static readonly uint WM_IME_ENDCOMPOSITION = 0x010E;
        public static readonly uint WM_IME_COMPOSITION = 0x010F;
        public static readonly uint WM_IME_KEYLAST = 0x010F;

        public static readonly uint WM_INITDIALOG = 0x0110;
        public static readonly uint WM_COMMAND = 0x0111;
        public static readonly uint WM_SYSCOMMAND = 0x0112;
        public static readonly uint WM_TIMER = 0x0113;
        public static readonly uint WM_HSCROLL = 0x0114;
        public static readonly uint WM_VSCROLL = 0x0115;
        public static readonly uint WM_INITMENU = 0x0116;
        public static readonly uint WM_INITMENUPOPUP = 0x0117;

        public static readonly uint WM_GESTURE = 0x0119;
        public static readonly uint WM_GESTURENOTIFY = 0x011A;

        public static readonly uint WM_MENUSELECT = 0x011F;
        public static readonly uint WM_MENUCHAR = 0x0120;
        public static readonly uint WM_ENTERIDLE = 0x0121;

        public static readonly uint WM_MENURBUTTONUP = 0x0122;
        public static readonly uint WM_MENUDRAG = 0x0123;
        public static readonly uint WM_MENUGETOBJECT = 0x0124;
        public static readonly uint WM_UNINITMENUPOPUP = 0x0125;
        public static readonly uint WM_MENUCOMMAND = 0x0126;

        public static readonly uint WM_CHANGEUISTATE = 0x0127;
        public static readonly uint WM_UPDATEUISTATE = 0x0128;
        public static readonly uint WM_QUERYUISTATE = 0x0129;

        public static readonly uint WM_CTLCOLORMSGBOX = 0x0132;
        public static readonly uint WM_CTLCOLOREDIT = 0x0133;
        public static readonly uint WM_CTLCOLORLISTBOX = 0x0134;
        public static readonly uint WM_CTLCOLORBTN = 0x0135;
        public static readonly uint WM_CTLCOLORDLG = 0x0136;
        public static readonly uint WM_CTLCOLORSCROLLBAR = 0x0137;
        public static readonly uint WM_CTLCOLORSTATIC = 0x0138;

        public static readonly uint WM_MOUSEFIRST = 0x0200;
        public static readonly uint WM_MOUSEMOVE = 0x0200;
        public static readonly uint WM_LBUTTONDOWN = 0x0201;
        public static readonly uint WM_LBUTTONUP = 0x0202;
        public static readonly uint WM_LBUTTONDBLCLK = 0x0203;
        public static readonly uint WM_RBUTTONDOWN = 0x0204;
        public static readonly uint WM_RBUTTONUP = 0x0205;
        public static readonly uint WM_RBUTTONDBLCLK = 0x0206;
        public static readonly uint WM_MBUTTONDOWN = 0x0207;
        public static readonly uint WM_MBUTTONUP = 0x0208;
        public static readonly uint WM_MBUTTONDBLCLK = 0x0209;

        public static readonly uint WM_MOUSEWHEEL = 0x020A;

        public static readonly uint WM_XBUTTONDOWN = 0x020B;
        public static readonly uint WM_XBUTTONUP = 0x020C;
        public static readonly uint WM_XBUTTONDBLCLK = 0x020D;

        public static readonly uint WM_MOUSEHWHEEL = 0x020E;

        public static readonly uint WM_MOUSELAST = 0x020E;
        //public static readonly uint WM_MOUSELAST = 0x020D;
        //public static readonly uint WM_MOUSELAST = 0x020A;
        //public static readonly uint WM_MOUSELAST = 0x0209;

        public static readonly uint WM_PARENTNOTIFY = 0x0210;
        public static readonly uint WM_ENTERMENULOOP = 0x0211;
        public static readonly uint WM_EXITMENULOOP = 0x0212;

        public static readonly uint WM_NEXTMENU = 0x0213;
        public static readonly uint WM_SIZING = 0x0214;
        public static readonly uint WM_CAPTURECHANGED = 0x0215;
        public static readonly uint WM_MOVING = 0x0216;

        public static readonly uint WM_POWERBROADCAST = 0x0218;

        public static readonly uint WM_DEVICECHANGE = 0x0219;

        public static readonly uint WM_MDICREATE = 0x0220;
        public static readonly uint WM_MDIDESTROY = 0x0221;
        public static readonly uint WM_MDIACTIVATE = 0x0222;
        public static readonly uint WM_MDIRESTORE = 0x0223;
        public static readonly uint WM_MDINEXT = 0x0224;
        public static readonly uint WM_MDIMAXIMIZE = 0x0225;
        public static readonly uint WM_MDITILE = 0x0226;
        public static readonly uint WM_MDICASCADE = 0x0227;
        public static readonly uint WM_MDIICONARRANGE = 0x0228;
        public static readonly uint WM_MDIGETACTIVE = 0x0229;

        public static readonly uint WM_MDISETMENU = 0x0230;
        public static readonly uint WM_ENTERSIZEMOVE = 0x0231;
        public static readonly uint WM_EXITSIZEMOVE = 0x0232;
        public static readonly uint WM_DROPFILES = 0x0233;
        public static readonly uint WM_MDIREFRESHMENU = 0x0234;

        public static readonly uint WM_POINTERDEVICECHANGE = 0x238;
        public static readonly uint WM_POINTERDEVICEINRANGE = 0x239;
        public static readonly uint WM_POINTERDEVICEOUTOFRANGE = 0x23A;

        public static readonly uint WM_TOUCH = 0x0240;

        public static readonly uint WM_NCPOINTERUPDATE = 0x0241;
        public static readonly uint WM_NCPOINTERDOWN = 0x0242;
        public static readonly uint WM_NCPOINTERUP = 0x0243;
        public static readonly uint WM_POINTERUPDATE = 0x0245;
        public static readonly uint WM_POINTERDOWN = 0x0246;
        public static readonly uint WM_POINTERUP = 0x0247;
        public static readonly uint WM_POINTERENTER = 0x0249;
        public static readonly uint WM_POINTERLEAVE = 0x024A;
        public static readonly uint WM_POINTERACTIVATE = 0x024B;
        public static readonly uint WM_POINTERCAPTURECHANGED = 0x024C;
        public static readonly uint WM_TOUCHHITTESTING = 0x024D;
        public static readonly uint WM_POINTERWHEEL = 0x024E;
        public static readonly uint WM_POINTERHWHEEL = 0x024F;

        public static readonly uint WM_IME_SETCONTEXT = 0x0281;
        public static readonly uint WM_IME_NOTIFY = 0x0282;
        public static readonly uint WM_IME_CONTROL = 0x0283;
        public static readonly uint WM_IME_COMPOSITIONFULL = 0x0284;
        public static readonly uint WM_IME_SELECT = 0x0285;
        public static readonly uint WM_IME_CHAR = 0x0286;

        public static readonly uint WM_IME_REQUEST = 0x0288;

        public static readonly uint WM_IME_KEYDOWN = 0x0290;
        public static readonly uint WM_IME_KEYUP = 0x0291;

        public static readonly uint WM_MOUSEHOVER = 0x02A1;
        public static readonly uint WM_MOUSELEAVE = 0x02A3;

        public static readonly uint WM_NCMOUSEHOVER = 0x02A0;
        public static readonly uint WM_NCMOUSELEAVE = 0x02A2;

        public static readonly uint WM_WTSSESSION_CHANGE = 0x02B1;

        public static readonly uint WM_TABLET_FIRST = 0x02c0;
        public static readonly uint WM_TABLET_LAST = 0x02df;

        public static readonly uint WM_CUT = 0x0300;
        public static readonly uint WM_COPY = 0x0301;
        public static readonly uint WM_PASTE = 0x0302;
        public static readonly uint WM_CLEAR = 0x0303;
        public static readonly uint WM_UNDO = 0x0304;
        public static readonly uint WM_RENDERFORMAT = 0x0305;
        public static readonly uint WM_RENDERALLFORMATS = 0x0306;
        public static readonly uint WM_DESTROYCLIPBOARD = 0x0307;
        public static readonly uint WM_DRAWCLIPBOARD = 0x0308;
        public static readonly uint WM_PAINTCLIPBOARD = 0x0309;
        public static readonly uint WM_VSCROLLCLIPBOARD = 0x030A;
        public static readonly uint WM_SIZECLIPBOARD = 0x030B;
        public static readonly uint WM_ASKCBFORMATNAME = 0x030C;
        public static readonly uint WM_CHANGECBCHAIN = 0x030D;
        public static readonly uint WM_HSCROLLCLIPBOARD = 0x030E;
        public static readonly uint WM_QUERYNEWPALETTE = 0x030F;
        public static readonly uint WM_PALETTEISCHANGING = 0x0310;
        public static readonly uint WM_PALETTECHANGED = 0x0311;
        public static readonly uint WM_HOTKEY = 0x0312;

        public static readonly uint WM_PRINT = 0x0317;
        public static readonly uint WM_PRINTCLIENT = 0x0318;

        public static readonly uint WM_APPCOMMAND = 0x0319;

        public static readonly uint WM_THEMECHANGED = 0x031A;

        public static readonly uint WM_CLIPBOARDUPDATE = 0x031D;

        public static readonly uint WM_DWMCOMPOSITIONCHANGED = 0x031E;
        public static readonly uint WM_DWMNCRENDERINGCHANGED = 0x031F;
        public static readonly uint WM_DWMCOLORIZATIONCOLORCHANGED = 0x0320;
        public static readonly uint WM_DWMWINDOWMAXIMIZEDCHANGE = 0x0321;

        public static readonly uint WM_DWMSENDICONICTHUMBNAIL = 0x0323;
        public static readonly uint WM_DWMSENDICONICLIVEPREVIEWBITMAP = 0x0326;

        public static readonly uint WM_GETTITLEBARINFOEX = 0x033F;

        public static readonly uint WM_HANDHELDFIRST = 0x0358;
        public static readonly uint WM_HANDHELDLAST = 0x035F;

        public static readonly uint WM_AFXFIRST = 0x0360;
        public static readonly uint WM_AFXLAST = 0x037F;

        public static readonly uint WM_PENWINFIRST = 0x0380;
        public static readonly uint WM_PENWINLAST = 0x038F;

        public static readonly uint WM_APP = 0x8000;

        public static readonly uint WM_USER = 0x0400;
    }
}
