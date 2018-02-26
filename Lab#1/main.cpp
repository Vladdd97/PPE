#if defined(UNICODE) && !defined(_UNICODE)
#define _UNICODE
#elif defined(_UNICODE) && !defined(UNICODE)
#define UNICODE
#endif
// yep

#include <tchar.h>
#include <windows.h>
#include <stdlib.h>

// id
#define GENERATE_BTN 100
#define DISPLAY_BTN 101
#define RED_BTN 102
#define ORANGE_BTN 103
#define AQUA_BTN 104
#define TEXT_INPUT 105

COLORREF bkgndcolor = RGB(222, 222, 222);

HWND hNameStatic;
HWND hNameEdit;
HWND hSurnameStatic;
HWND hSurnameEdit;
HWND hGroupStatic;
HWND hGroupEdit;
HWND hInputText;
HWND hGenerateButton;
HWND hDisplayButton;
HWND hAquaButton;
HWND hRedButton;
HWND hOrangeButton;

HINSTANCE hInst;

void AddControls(HWND);

/*  Declare Windows procedure  */
LRESULT CALLBACK WindowProcedure(HWND, UINT, WPARAM, LPARAM);

/*  Make the class name into a global variable  */
TCHAR szClassName[] = _T("PPE[Lab-1]");

int WINAPI WinMain(HINSTANCE hThisInstance,
    HINSTANCE hPrevInstance,
    LPSTR lpszArgument,
    int nCmdShow)
{
    HWND hwnd; /* This is the handle for our window */
    MSG messages; /* Here messages to the application are saved */
    WNDCLASSEX wincl; /* Data structure for the windowclass */

    /* The Window structure */
    wincl.hInstance = hThisInstance;
    wincl.lpszClassName = szClassName;
    wincl.lpfnWndProc = WindowProcedure; /* This function is called by windows */
    wincl.style = CS_DBLCLKS; /* Catch double-clicks */
    wincl.cbSize = sizeof(WNDCLASSEX);
    /* Use default icon and mouse-pointer */
    wincl.hIcon = LoadIcon(NULL, IDI_APPLICATION);
    wincl.hIconSm = LoadIcon(NULL, IDI_APPLICATION);
    wincl.hCursor = LoadCursor(NULL, IDC_ARROW);
    wincl.lpszMenuName = NULL; /* No menu */
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
        _T("PPE[Lab-1]"), /* Title Text */
        WS_OVERLAPPEDWINDOW, /* default window */
        CW_USEDEFAULT, /* Windows decides the position */
        CW_USEDEFAULT, /* where the window ends up on the screen */
        600, /* The programs width */
        400, /* and height in pixels */
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
    int screenW, screenH, cxCoord, cyCoord;
    RECT rect;
    HDC hdc = NULL;
    HBRUSH textArea1Brush;

    PAINTSTRUCT ps;
    HFONT fontStatic, fontButton, fontInput;

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

    case WM_COMMAND: {
        switch (LOWORD(wParam)) {
        case DISPLAY_BTN: {

            int len = GetWindowTextLength(hInputText) + 1;
            static char display[500];

            GetWindowText(hInputText, display, len);
            MessageBox(hwnd, display, "Message box", MB_OK | MB_ICONINFORMATION);

            break;
        }

        case GENERATE_BTN: {
            int nameLen, surnameLen, groupLen;
            char name[30], surname[30], group[30], text[200];
            nameLen = GetWindowTextLength(hNameEdit) + 1;
            surnameLen = GetWindowTextLength(hSurnameEdit) + 1;
            groupLen = GetWindowTextLength(hGroupEdit) + 1;
            GetWindowText(hNameEdit, name, nameLen);
            GetWindowText(hSurnameEdit, surname, surnameLen);
            GetWindowText(hGroupEdit, group, groupLen);
            strcpy(text, name);
            strcat(text, " ");
            strcat(text, surname);
            strcat(text, " is from ");
            strcat(text, group);
            strcat(text, " group .");
            SetWindowText(hInputText, text);
            break;
        }

        case AQUA_BTN: {
            bkgndcolor = RGB(0, 255, 255);
            InvalidateRect(hwnd, NULL, TRUE);

            break;
        }
        case RED_BTN: {
            bkgndcolor = RGB(255, 0, 0);
            InvalidateRect(hwnd, NULL, TRUE);

            break;
        }
        case ORANGE_BTN: {
            bkgndcolor = RGB(255, 128, 0);
            InvalidateRect(hwnd, NULL, TRUE);

            break;
        }
        }
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

    // message is sent to all top-level windows when a change is made to a system color setting
    case WM_SYSCOLORCHANGE: {
        InvalidateRect(hwnd, NULL, TRUE);

        break;
    }
    //A window receives this message when the user chooses
    //the maximize button, minimize button, restore button, or close button
    case WM_SYSCOMMAND: {
        switch (wParam) {

        case SC_MINIMIZE: {
            return MessageBox(NULL, TEXT(" It is a bad idea! "), TEXT("Minimize Button Clicked!"), MB_OK | MB_ICONSTOP);
        }
        case SC_MAXIMIZE: {
            if (MessageBox(hwnd, "Are you sure you wanna leave?", "Close App", MB_OKCANCEL) == IDOK)
                DestroyWindow(hwnd);
            break;
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

    // An edit control that is not read-only or disabled sends
    // the WM_CTLCOLOREDIT message to its parent window when the control is about to be drawn.
    case WM_CTLCOLOREDIT: {
        if (TEXT_INPUT == GetDlgCtrlID((HWND)lParam)) {
            textArea1Brush = CreateSolidBrush(RGB(184, 197, 174));
            SetBkMode((HDC)wParam, TRANSPARENT);
            return (INT_PTR)textArea1Brush;
        }
        break;
    }

    // used for changing background color of static windows
    case WM_CTLCOLORSTATIC: {
        HDC hdcStatic = (HDC)wParam;
        SetBkMode(hdcStatic, TRANSPARENT);
        return (INT_PTR)(HBRUSH)GetStockObject(NULL_BRUSH);
        break;
    }

    case WM_PAINT: {
        hdc = BeginPaint(hwnd, &ps);
        SetBkMode(hdc, TRANSPARENT);
        GetClientRect(hwnd, &rect);
        fontButton = CreateFont(17, 0, 0, 0, FW_DEMIBOLD, false, false, false,
            DEFAULT_CHARSET, OUT_DEFAULT_PRECIS, CLIP_DEFAULT_PRECIS,
            DEFAULT_QUALITY, FF_DONTCARE, "Buttons");

        fontStatic = CreateFont(18, 0, 0, 0, FW_LIGHT, false, false, false,
            DEFAULT_CHARSET, OUT_DEFAULT_PRECIS, CLIP_DEFAULT_PRECIS,
            DEFAULT_QUALITY, FF_DONTCARE, "StaticWindow");

        fontInput = CreateFont(22, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, TEXT("Courier New"));
        SendMessage(hGenerateButton, WM_SETFONT, (WPARAM)fontButton, 1);

        SendMessage(hNameStatic, WM_SETFONT, (WPARAM)fontStatic, 1);
        SendMessage(hSurnameStatic, WM_SETFONT, (WPARAM)fontStatic, 1);
        SendMessage(hGroupStatic, WM_SETFONT, (WPARAM)fontStatic, 1);
        SendMessage(hInputText, WM_SETFONT, (WPARAM)fontInput, 1);
        SetTextColor(hdc, RGB(10, 0, 255));
        DrawText(hdc, TEXT("Fill the fields and press GENERATE"), -1, &rect, DT_SINGLELINE | DT_CENTER | DT_TOP);
        EndPaint(hwnd, &ps);
        break;
    }
    // used for set Min and Max size of the window
    case WM_GETMINMAXINFO: {
        LPMINMAXINFO winSize = (LPMINMAXINFO)lParam;
        winSize->ptMinTrackSize.x = 580;
        winSize->ptMinTrackSize.y = 385;
        winSize->ptMaxTrackSize.x = 800;
        winSize->ptMaxTrackSize.y = 500;
        break;

        break;
    }

    case WM_DRAWITEM: {
        if ((UINT)wParam == GENERATE_BTN) {
            LPDRAWITEMSTRUCT lpdis = (DRAWITEMSTRUCT*)lParam;
            SIZE size;
            char szGenerateBtnText[9];

            strcpy(szGenerateBtnText, "GENERATE");
            GetTextExtentPoint32(lpdis->hDC, szGenerateBtnText, strlen(szGenerateBtnText), &size);
            SetTextColor(lpdis->hDC, RGB(214, 40, 34));
            SetBkColor(lpdis->hDC, RGB(0, 255, 64));

            ExtTextOut(
                lpdis->hDC,
                ((lpdis->rcItem.right - lpdis->rcItem.left) - size.cx) / 2,
                ((lpdis->rcItem.bottom - lpdis->rcItem.top) - size.cy) / 2,
                ETO_OPAQUE | ETO_CLIPPED,
                &lpdis->rcItem,
                szGenerateBtnText,
                strlen(szGenerateBtnText),
                NULL);

            DrawEdge(
                lpdis->hDC,
                &lpdis->rcItem,
                (lpdis->itemState & ODS_SELECTED ? EDGE_SUNKEN : EDGE_RAISED),
                BF_RECT);
            return TRUE;
        }
        break;
    }

    case WM_SIZE: {

        cxCoord = LOWORD(lParam);
        cyCoord = HIWORD(lParam);

        MoveWindow(hGenerateButton, (cxCoord / 2) - 50, (cyCoord / 2) - 20, 100, 40, TRUE);
        MoveWindow(hInputText, 20, cyCoord - 150, 350, 100, TRUE);
        MoveWindow(hDisplayButton, 20, cyCoord - 40, 110, 30, TRUE);
        MoveWindow(hAquaButton, cxCoord - 180, cyCoord - 160, 80, 30, TRUE);
        MoveWindow(hRedButton, cxCoord - 180, cyCoord - 120, 80, 30, TRUE);
        MoveWindow(hOrangeButton, cxCoord - 180, cyCoord - 80, 80, 30, TRUE);
        break;
    }

    case WM_DESTROY:
        PostQuitMessage(0); /* send a WM_QUIT to the message queue */
        break;
    default: /* for messages that we don't deal with */
        return DefWindowProc(hwnd, message, wParam, lParam);
    }

    return 0;
}

void AddControls(HWND hwnd)
{

    hNameStatic = CreateWindowEx(
        (DWORD)NULL,
        TEXT("static"),
        TEXT("Name :"),
        WS_VISIBLE | WS_CHILD,
        20, 40,
        75, 20,
        hwnd,
        (HMENU)NULL,
        hInst,
        NULL);

    hNameEdit = CreateWindowEx(
        (DWORD)NULL,
        TEXT("edit"),
        TEXT("..."),
        WS_VISIBLE | WS_CHILD | WS_BORDER,
        105, 40,
        200, 20,
        hwnd,
        (HMENU)NULL,
        hInst,
        NULL);

    hSurnameStatic = CreateWindowEx(
        (DWORD)NULL,
        TEXT("static"),
        TEXT("Surname :"),
        WS_VISIBLE | WS_CHILD,
        20, 70,
        75, 20,
        hwnd,
        (HMENU)NULL,
        hInst,
        NULL);

    hSurnameEdit = CreateWindowEx(
        (DWORD)NULL,
        TEXT("edit"),
        TEXT("..."),
        WS_VISIBLE | WS_CHILD | WS_BORDER,
        105, 70,
        200, 20,
        hwnd,
        (HMENU)NULL,
        hInst,
        NULL);

    hGroupStatic = CreateWindowEx(
        (DWORD)NULL,
        TEXT("static"),
        TEXT("Group :"),
        WS_VISIBLE | WS_CHILD,
        20, 100,
        75, 20,
        hwnd,
        (HMENU)NULL,
        hInst,
        NULL);

    hGroupEdit = CreateWindowEx(
        (DWORD)NULL,
        TEXT("edit"),
        TEXT("..."),
        WS_VISIBLE | WS_CHILD | WS_BORDER,
        105, 100,
        200, 20,
        hwnd,
        (HMENU)NULL,
        hInst,
        NULL);

    hGenerateButton = CreateWindowEx(
        (DWORD)NULL,
        TEXT("button"),
        TEXT("Generate"),
        WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON | BS_OWNERDRAW,
        140, 130, 100, 40,
        hwnd,
        (HMENU)GENERATE_BTN,
        hInst,
        NULL);

    hInputText = CreateWindowEx(
        (DWORD)NULL,
        TEXT("edit"),
        TEXT("..."),
        WS_CHILD | WS_VISIBLE | WS_BORDER | WS_VSCROLL | ES_MULTILINE,
        20, 210,
        350, 100,
        hwnd,
        (HMENU)TEXT_INPUT,
        hInst,
        NULL);

    hDisplayButton = CreateWindowEx(
        (DWORD)NULL,
        TEXT("button"),
        TEXT("Display Text"),
        WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
        20, 320, 110, 30,
        hwnd,
        (HMENU)DISPLAY_BTN,
        hInst,
        NULL);

    hAquaButton = CreateWindowEx(
        (DWORD)NULL,
        TEXT("button"),
        TEXT("Aqua"),
        WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
        390, 205, 80, 30,
        hwnd,
        (HMENU)AQUA_BTN,
        hInst,
        NULL);

    hRedButton = CreateWindowEx(
        (DWORD)NULL,
        TEXT("button"),
        TEXT("Red"),
        WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
        390, 245, 80, 30,
        hwnd,
        (HMENU)RED_BTN,
        hInst,
        NULL);

    hOrangeButton = CreateWindowEx(
        (DWORD)NULL,
        TEXT("button"),
        TEXT("Orange"),
        WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
        390, 285, 80, 30,
        hwnd,
        (HMENU)ORANGE_BTN,
        hInst,
        NULL);
}
