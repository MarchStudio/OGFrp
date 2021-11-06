#pragma once
#include <Windows.h>
#include <Winhttp.h>
#include <stdio.h>
#pragma comment(lib, "Winhttp.lib")

typedef void (*DownLoadCallback)(int ContentSize, int CUR_LEN);

typedef struct _URL_INFO {
    WCHAR szScheme[512];
    WCHAR szHostName[512];
    WCHAR szUserName[512];
    WCHAR szPassword[512];
    WCHAR szUrlPath[512];
    WCHAR szExtraInfo[512];
} URL_INFO, *PURL_INFO;

void dcallback(int ContentSize, int file_size) {
    printf("count:%d,size:%d\n", ContentSize, file_size);
}

void download(const wchar_t* Url, const wchar_t* FileName, DownLoadCallback Func) {
    URL_INFO url_info = {0};
    URL_COMPONENTSW lpUrlComponents = {0};
    lpUrlComponents.dwStructSize = sizeof(lpUrlComponents);
    lpUrlComponents.lpszExtraInfo = url_info.szExtraInfo;
    lpUrlComponents.lpszHostName = url_info.szHostName;
    lpUrlComponents.lpszPassword = url_info.szPassword;
    lpUrlComponents.lpszScheme = url_info.szScheme;
    lpUrlComponents.lpszUrlPath = url_info.szUrlPath;
    lpUrlComponents.lpszUserName = url_info.szUserName;

    lpUrlComponents.dwExtraInfoLength =
        lpUrlComponents.dwHostNameLength =
            lpUrlComponents.dwPasswordLength =
                lpUrlComponents.dwSchemeLength =
                    lpUrlComponents.dwUrlPathLength =
                        lpUrlComponents.dwUserNameLength = 512;

    WinHttpCrackUrl(Url, 0, ICU_ESCAPE, &lpUrlComponents);

    // ����һ���Ự
    HINTERNET hSession = WinHttpOpen(NULL, WINHTTP_ACCESS_TYPE_NO_PROXY, NULL, NULL, 0);
    DWORD dwReadBytes, dwSizeDW = sizeof(dwSizeDW), dwContentSize, dwIndex = 0;
    // ����һ������
    HINTERNET hConnect = WinHttpConnect(hSession, lpUrlComponents.lpszHostName, lpUrlComponents.nPort, 0);
    // ����һ�������Ȳ�ѯ���ݵĴ�С
    HINTERNET hRequest = WinHttpOpenRequest(hConnect, L"HEAD", lpUrlComponents.lpszUrlPath, L"HTTP/1.1", WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, WINHTTP_FLAG_REFRESH);
    WinHttpSendRequest(hRequest, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REQUEST_DATA, 0, 0, 0);
    WinHttpReceiveResponse(hRequest, 0);
    WinHttpQueryHeaders(hRequest, WINHTTP_QUERY_CONTENT_LENGTH | WINHTTP_QUERY_FLAG_NUMBER, NULL, &dwContentSize, &dwSizeDW, &dwIndex);
    WinHttpCloseHandle(hRequest);

    // ����һ�����󣬻�ȡ����
    hRequest = WinHttpOpenRequest(hConnect, L"GET", lpUrlComponents.lpszUrlPath, L"HTTP/1.1", WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, WINHTTP_FLAG_REFRESH);
    WinHttpSendRequest(hRequest, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REQUEST_DATA, 0, 0, 0);
    WinHttpReceiveResponse(hRequest, 0);

    // �ֶλص���ʾ����
    DWORD BUF_LEN = 1024, ReadedLen = 0;
    BYTE* pBuffer = NULL;
    pBuffer = new BYTE[BUF_LEN];

    HANDLE hFile = CreateFileW(FileName, GENERIC_WRITE, FILE_SHARE_READ, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);

    while (dwContentSize > ReadedLen) {
        ZeroMemory(pBuffer, BUF_LEN);
        WinHttpReadData(hRequest, pBuffer, BUF_LEN, &dwReadBytes);
        ReadedLen += dwReadBytes;

        // д���ļ�
        WriteFile(hFile, pBuffer, dwReadBytes, &dwReadBytes, NULL);
        // ���Ȼص�
        Func(dwContentSize, ReadedLen);
    }

    CloseHandle(hFile);
    delete pBuffer;

    /*
    // һ����д�������ļ�
    BYTE *pBuffer = NULL;

    pBuffer = new BYTE[dwContentSize];
    ZeroMemory(pBuffer, dwContentSize);
    //do{
        WinHttpReadData(hRequest, pBuffer, dwContentSize, &dwReadBytes);
        Func(dwContentSize, dwReadBytes);
    //} while (dwReadBytes == 0);


    HANDLE hFile = CreateFileW(FileName, GENERIC_WRITE, FILE_SHARE_READ, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
    WriteFile(hFile, pBuffer, dwContentSize, &dwReadBytes, NULL);
    CloseHandle(hFile);

    delete pBuffer;
    */
    WinHttpCloseHandle(hRequest);
    WinHttpCloseHandle(hConnect);
    WinHttpCloseHandle(hSession);
}

int main(int argc, char* argv[]) {
    download(L"http://sw.bos.baidu.com/sw-search-sp/software/58d7820029ae7/BaiduMusic_10.1.7.7_setup.exe", L"./BaiduMusic_10.1.7.7_setup.exe", &dcallback);
    system("pause");
}