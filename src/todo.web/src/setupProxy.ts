//const { createProxyMiddleware } = require('http-proxy-middleware');
import { createProxyMiddleware, Filter, Options, RequestHandler } from 'http-proxy-middleware';
const context: Filter = [
    "/weatherforecast"];

export default (app: { use: (arg0: RequestHandler) => void; }) => {
    const options: Options = { target: 'https://localhost:5001', secure: true, changeOrigin: true } as Options;
    const appProxy = createProxyMiddleware(context, options);
    app.use(appProxy);
};