const { app, BrowserWindow } = require('electron'); // 保持对window对象的全局引用

let win;

function createWindow() {
    // 创建浏览器窗口
    win = new BrowserWindow({
        width: 800,
        height: 600,
        webPreferences: {
            nodeIntegration: true
        }
    });

    win.title = "OGFrp Panel";                     // 设置窗口标题
    win.menuBarVisible = false;                    // 隐藏菜单栏
    win.loadURL("https://ogfrp.cn/?page=login");   // 加载网页
    win.on('closed', () => {
        win = null                                 // 取消引用 window 对象
    });
}

app.on('ready', createWindow);                     // 初始化后创建窗口

// 当全部窗口关闭时退出。
app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') {
        app.quit();
    };
})

app.on('activate', () => {
    // 在macOS上，当单击dock图标并且没有其他窗口打开时，
    // 通常在应用程序中重新创建一个窗口。
    if (win === null) {
        createWindow();
    };
})
