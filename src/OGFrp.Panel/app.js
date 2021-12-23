const { app, BrowserWindow } = require('electron'); // ���ֶ�window�����ȫ������

let win;

function createWindow() {
    // �������������
    win = new BrowserWindow({
        width: 800,
        height: 600,
        webPreferences: {
            nodeIntegration: true
        }
    });

    win.title = "OGFrp Panel";                     // ���ô��ڱ���
    win.menuBarVisible = false;                    // ���ز˵���
    win.loadURL("https://ogfrp.cn/?page=login");   // ������ҳ
    win.on('closed', () => {
        win = null                                 // ȡ������ window ����
    });
}

app.on('ready', createWindow);                     // ��ʼ���󴴽�����

// ��ȫ�����ڹر�ʱ�˳���
app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') {
        app.quit();
    };
})

app.on('activate', () => {
    // ��macOS�ϣ�������dockͼ�겢��û���������ڴ�ʱ��
    // ͨ����Ӧ�ó��������´���һ�����ڡ�
    if (win === null) {
        createWindow();
    };
})
