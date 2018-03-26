#if defined(UNICODE) && !defined(_UNICODE)
#define _UNICODE
#elif defined(_UNICODE) && !defined(UNICODE)
#define UNICODE
#endif

#include <tchar.h>
#include <windows.h>
#include "resource.h"

HWND hwnd; /* This is the handle for our window */
HWND hAddClassmate;
HWND hRemoveClassmate;
HWND hClearListBox;
HWND hNameSurnameStatic;
HWND hNameSurnameEdit;

HWND hWidthScroll;
HWND hHeightScroll;
SCROLLINFO si;

HWND hListBox;
HINSTANCE hInst;
COLORREF bkgndcolor = RGB(222, 222, 222);

int cxMainWindowOffset = 0;
int cyMainWindowOffset = 0;
int widthScrollPos = 0;
int heightScrollPos = 0;

void AddControls(HWND);

/*  Declare Windows procedure  */
LRESULT CALLBACK WindowProcedure(HWND, UINT, WPARAM, LPARAM);
LRESULT CALLBACK DlgProc(HWND hWndDlg, UINT Msg, WPARAM wParam, LPARAM lParam);

/*  Make the class name into a global variable  */
TCHAR szClassName[] = _T("PPE[Lab-2]");

int WINAPI WinMain(HINSTANCE hThisInstance,
    HINSTANCE hPrevInstance,
    LPSTR lpszArgument,
    int nCmdShow)
{

    MSG messages; /* Here messages to the application are saved */
    WNDCLASSEX wincl; /* Data structure for the windowclass */

    /* The Window structure */
    wincl.hInstance = hThisInstance;
    wincl.lpszClassName = szClassName;
    wincl.lpfnWndProc = WindowProcedure; /* This function is called by windows */
    wincl.style = CS_DBLCLKS; /* Catch double-clicks */
    wincl.cbSize = sizeof(WNDCLASSEX);

    /* Use default icon and mouse-pointer */
    wincl.hIcon = LoadIcon(GetModuleHandle(NULL), MAKEINTRESOURCE(IDI_MYICON));
    wincl.hIconSm = (HICON)LoadImage(GetModuleHandle(NULL), MAKEINTRESOURCE(IDI_MYICON), IMAGE_ICON, 16, 16, 0);
    wincl.hCursor = LoadCursor(NULL, IDC_CROSS);
    wincl.lpszMenuName = MAKEINTRESOURCE(IDR_MYMENU); /* Add menu */
    wincl.cbClsExtra = 0; /* No extra bytes after the window class */
    wincl.cbWndExtra = 0; /* structure or the window instance */
    /* Use Windows's default colour as the background of the window */
    wincl.hbrBackground = (HBRUSH)COLOR_BACKGROUND;

    /* Register the window class, and if it fails quit the program */
    if (!RegisterClassEx(&wincl))
        return 0;

    /* The class is registered, let's create the program*/
    hwnd = CreateWindowEx(
        0, /* Extended possibilites for variation */
        szClassName, /* Classname */
        _T("PPE[Lab-2]"), /* Title Text */
        WS_OVERLAPPEDWINDOW, /* default window */
        CW_USEDEFAULT, /* Windows decides the position */
        CW_USEDEFAULT, /* where the window ends up on the screen */
        544, /* The programs width */
        375, /* and height in pixels */
        HWND_DESKTOP, /* The window is a child-window to desktop */
        NULL, /* No menu */
        hThisInstance, /* Program Instance handler */
        NULL /* No Window Creation data */
        );

    /* Make the window visible on the screen */
    ShowWindow(hwnd, nCmdShow);
    /* Run the message loop. It will run until GetMessage() returns 0 */
    while (GetMessage(&messages, NULL, 0, 0)) {
        /* Translate virtual-key messages into character messages */
        TranslateMessage(&messages);
        /* Send message to WindowProcedure */
        DispatchMessage(&messages);
    }

    /* The program return-value is 0 - The value that PostQuitMessage() gave */
    return messages.wParam;
}

/*  This function is called by the Windows function DispatchMessage()  */

LRESULT CALLBACK WindowProcedure(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    int screenW, screenH;
    RECT rect;
    HDC hdc = NULL;
    PAINTSTRUCT ps;

    switch (message) /* handle the messages */
    {

    case WM_CREATE: {

        //Getting information about screen width and height
        screenW = GetSystemMetrics(SM_CXSCREEN);
        screenH = GetSystemMetrics(SM_CYSCREEN);
        //Retrieves the coordinates of a window's client area
        GetClientRect(hwnd, &rect);

        SetWindowPos(
            hwnd, 0,
            (screenW - rect.right) / 2,
            (screenH - rect.bottom) / 2,
            0, 0,
            SWP_NOZORDER | SWP_NOSIZE);
        // ...

        AddControls(hwnd);
        break;
    }

    case WM_GETMINMAXINFO: {
        LPMINMAXINFO winSize = (LPMINMAXINFO)lParam;
        winSize->ptMinTrackSize.x = 580;
        winSize->ptMinTrackSize.y = 385;
        winSize->ptMaxTrackSize.x = 620;
        winSize->ptMaxTrackSize.y = 420;
        break;
    }

    // Sent when the window background must be erased
    case WM_ERASEBKGND: {
        HPEN pen;
        HBRUSH brush;
        RECT rect;

        pen = CreatePen(PS_SOLID, 1, bkgndcolor);
        brush = CreateSolidBrush(bkgndcolor);
        SelectObject((HDC)wParam, pen);
        SelectObject((HDC)wParam, brush);
        GetClientRect(hwnd, &rect);
        Rectangle((HDC)wParam, rect.left, rect.top, rect.right, rect.bottom);

        break;
    }

    case WM_COMMAND: {

        switch (LOWORD(wParam)) {

        case ID_FILE_ABOUT: {

            char display[] = "This application is created by : \nBantus Vladislav\nas laboratory work nr.2 for PPE";
            MessageBox(hwnd, display, "Message box", MB_OK | MB_ICONINFORMATION);
            break;
        }

        case ID_FILE_EXIT: {
            DialogBox(hInst, MAKEINTRESOURCE(ID_DIALOGBOX_BLACKCOLOR),
                hwnd, reinterpret_cast<DLGPROC>(DlgProc));
            break;
        }

        case ID_COLORS_BLUE: {
            bkgndcolor = RGB(0, 0, 255);
            InvalidateRect(hwnd, NULL, TRUE);

            break;
        }

        case ID_COLORS_RED: {
            bkgndcolor = RGB(255, 0, 0);
            InvalidateRect(hwnd, NULL, TRUE);

            break;
        }

        case ID_COLORS_YELLOW: {
            bkgndcolor = RGB(255, 255, 0);
            InvalidateRect(hwnd, NULL, TRUE);

            break;
        }

        case ID_BTN_ADDCLASSMATE: {

            int textLen;
            char text[30];
            textLen = GetWindowTextLength(hNameSurnameEdit) + 1;
            GetWindowText(hNameSurnameEdit, text, textLen);
            if (textLen > 1) {
                char text2[] = "- ";
                strcat(text2, text);
                SendMessage(hListBox, LB_ADDSTRING, 0, (LPARAM)text2);
            }
            break;
        }

        case ID_BTN_REMOVECLASSMATE: {
            LRESULT name = SendMessage(hListBox, LB_GETCURSEL, 0, 0);
            if (name != LB_ERR) {
                SendMessage(hListBox, LB_DELETESTRING, name, 0);
            }
            break;
        }

        case ID_BTN_CLEARLISTBOX: {
            SendMessage(hListBox, LB_RESETCONTENT, 0, 0);
            break;
        }

        case ID_FEATURES_JUMPAROUND: {
            int x, y;
            x = (rand() % 100 + 1);
            y = (rand() % 100 + 1);
            SetWindowPos(
                hwnd, 0,
                x,
                y,
                0, 0,
                SWP_NOZORDER | SWP_NOSIZE);
            break;
        }
        }
        break;
    }

    case WM_SIZE: {
        int iWidth = LOWORD(lParam);
        int iHeight = HIWORD(lParam);

        // Set horizontal scroll bar range and page size
        break;
    }

    case WM_VSCROLL: {

    case ID_HEIGHT_SCROLL: {
        screenW = GetSystemMetrics(SM_CXSCREEN);
        screenH = GetSystemMetrics(SM_CYSCREEN);
        GetClientRect(hwnd, &rect);
        switch (LOWORD(wParam)) {
        case SB_LINELEFT:
            if (heightScrollPos > 0) {

                heightScrollPos -= 1;

                cyMainWindowOffset = heightScrollPos * 5;
                SetWindowPos(
                    hwnd, 0,
                    (screenW - rect.right) / 2,
                    (screenH - rect.bottom) / 2 + cyMainWindowOffset,
                    0, 0,
                    SWP_NOZORDER | SWP_NOSIZE);
            }
            break;
        case SB_LINERIGHT:
            if (heightScrollPos < 10) {
                heightScrollPos += 1;

                cyMainWindowOffset = heightScrollPos * 5;
                SetWindowPos(
                    hwnd, 0,
                    (screenW - rect.right) / 2,
                    (screenH - rect.bottom) / 2 + cyMainWindowOffset,
                    0, 0,
                    SWP_NOZORDER | SWP_NOSIZE);
            }
            break;
        case SB_THUMBPOSITION:
            heightScrollPos = HIWORD(wParam);
            break;
        default:
            break;
        }
        SetScrollPos(hHeightScroll, SB_CTL, heightScrollPos, TRUE);
        break;
    } break;
    }

    case WM_HSCROLL: {

        switch (GetWindowLong((HWND)lParam, GWL_ID)) {

        case ID_WIDTH_SCROLL: {
            screenW = GetSystemMetrics(SM_CXSCREEN);
            screenH = GetSystemMetrics(SM_CYSCREEN);
            GetClientRect(hwnd, &rect);
            switch (LOWORD(wParam)) {
            case SB_LINELEFT:
                if (widthScrollPos > 0) {
                    widthScrollPos -= 1;
                    cxMainWindowOffset = widthScrollPos * 5;
                    SetWindowPos(
                        hwnd, 0,
                        (screenW - rect.right) / 2 + cxMainWindowOffset,
                        (screenH - rect.bottom) / 2,
                        0, 0,
                        SWP_NOZORDER | SWP_NOSIZE);
                }
                break;
            case SB_LINERIGHT:
                if (widthScrollPos < 10) {
                    widthScrollPos += 1;
                    cxMainWindowOffset = widthScrollPos * 5;
                    SetWindowPos(
                        hwnd, 0,
                        (screenW - rect.right) / 2 + cxMainWindowOffset,
                        (screenH - rect.bottom) / 2,
                        0, 0,
                        SWP_NOZORDER | SWP_NOSIZE);
                }
                break;
            case SB_THUMBPOSITION:
                widthScrollPos = HIWORD(wParam);
                break;
            }
            SetScrollPos(hWidthScroll, SB_CTL, widthScrollPos, TRUE);

            break;
        }

        break;
        }
    }

    case WM_SYSCOMMAND: {
        switch (wParam) {

        case SC_MINIMIZE: {
            return MessageBox(NULL, TEXT(" It is a bad idea! "), TEXT("Minimize Button Clicked!"), MB_OK | MB_ICONSTOP);
        }
        case SC_MAXIMIZE: {
            return MessageBox(NULL, TEXT(" What are you doing > ? < "), TEXT("Maximize Button Clicked!"), MB_OK | MB_ICONQUESTION);
        }
        case SC_CLOSE: {
            int x, y;
            x = (rand() % 100 + 1);
            y = (rand() % 100 + 1);
            SetWindowPos(
                hwnd, 0,
                x,
                y,
                0, 0,
                SWP_NOZORDER | SWP_NOSIZE);
            break;
        }

        default:
            return DefWindowProc(hwnd, message, wParam, lParam);
        }
        break;
    }

    case WM_PAINT: {
        hdc = BeginPaint(hwnd, &ps);
        SetBkMode(hdc, TRANSPARENT);
        GetClientRect(hwnd, &rect);

        SetTextColor(hdc, RGB(255, 44, 25));
        DrawText(hdc, TEXT("Add all your classmates in the ListBox !!!"), -1, &rect, DT_SINGLELINE | DT_CENTER | DT_TOP);
        EndPaint(hwnd, &ps);
        break;
    }

    case WM_KEYDOWN: {
        switch (wParam) {

        case 0x42: { // 0x42 is the virtual key for "B" character

            bkgndcolor = RGB(0, 0, 0);
            InvalidateRect(hwnd, NULL, TRUE);

            break;
        }

        case 0x57: { // 0x57 is the virtual key for "W" character
            bkgndcolor = RGB(255, 255, 255);
            InvalidateRect(hwnd, NULL, TRUE);

            break;
        }

        break;
        }
        break;
    }

    case WM_DESTROY: {
        PostQuitMessage(0); /* send a WM_QUIT to the message queue */
        break;
    }

    default: /* for messages that we don't deal with */
        return DefWindowProc(hwnd, message, wParam, lParam);
    }

    return 0;
}

void AddControls(HWND hWnd)
{

    hListBox = CreateWindowEx((DWORD)NULL,
        TEXT("LISTBOX"),
        "",
        WS_CHILD | WS_VISIBLE | WS_VSCROLL | ES_AUTOVSCROLL | LBS_STANDARD | WS_BORDER,
        10, 80,
        300, 100,
        hWnd,
        (HMENU)ID_LIST_BOX,
        hInst,
        NULL);

    hNameSurnameStatic = CreateWindowEx(
        (DWORD)NULL,
        TEXT("static"),
        TEXT("Name and Surname :"),
        WS_VISIBLE | WS_CHILD,
        10, 40,
        100, 30,
        hWnd,
        (HMENU)NULL,
        hInst,
        NULL);

    hNameSurnameEdit = CreateWindowEx(
        (DWORD)NULL,
        TEXT("edit"),
        TEXT("..."),
        WS_VISIBLE | WS_CHILD | WS_BORDER,
        120, 45,
        170, 20,
        hWnd,
        (HMENU)NULL,
        hInst,
        NULL);

    hAddClassmate = CreateWindowEx(
        (DWORD)NULL,
        TEXT("button"),
        TEXT("Add Classmate"),
        WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
        320, 75, 150, 30,
        hWnd,
        (HMENU)ID_BTN_ADDCLASSMATE,
        hInst,
        NULL);

    hRemoveClassmate = CreateWindowEx(
        (DWORD)NULL,
        TEXT("button"),
        TEXT("Remove Classmate"),
        WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
        320, 115, 150, 30,
        hWnd,
        (HMENU)ID_BTN_REMOVECLASSMATE,
        hInst,
        NULL);

    hClearListBox = CreateWindowEx(
        (DWORD)NULL,
        TEXT("button"),
        TEXT("Clear All"),
        WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
        320, 155, 150, 30,
        hWnd,
        (HMENU)ID_BTN_CLEARLISTBOX,
        hInst,
        NULL);

    hWidthScroll = CreateWindowEx((DWORD)NULL,
        TEXT("scrollbar"),
        NULL,
        WS_CHILD | WS_VISIBLE | SBS_HORZ,
        10, 250, 250, 20,
        hWnd,
        (HMENU)ID_WIDTH_SCROLL,
        hInst,
        NULL);

    SetScrollRange(hWidthScroll, SB_CTL, 0, 10, TRUE);
    SetScrollPos(hWidthScroll, SB_CTL, 0, TRUE);

    hHeightScroll = CreateWindowEx((DWORD)NULL,
        TEXT("scrollbar"),
        NULL,
        WS_CHILD | WS_VISIBLE | SBS_VERT,
        510, 20, 20, 250,
        hWnd,
        (HMENU)ID_HEIGHT_SCROLL,
        hInst,
        NULL);

    SetScrollRange(hHeightScroll, SB_CTL, 0, 10, TRUE);
    SetScrollPos(hHeightScroll, SB_CTL, 0, TRUE);
}

LRESULT CALLBACK DlgProc(HWND hWndDlg, UINT Msg, WPARAM wParam, LPARAM lParam)
{
    switch (Msg) {
    case WM_INITDIALOG:
        return TRUE;

    case WM_COMMAND:
        switch (wParam) {
        case IDOK:
            PostMessage(hwnd, WM_CLOSE, 0, 0);
            break;
        case IDCANCEL:
            EndDialog(hWndDlg, IDCANCEL);
            break;
            break;
        }
    }

    return FALSE;
}
