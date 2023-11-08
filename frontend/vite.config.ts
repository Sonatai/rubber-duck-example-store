import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

// https://vitejs.dev/config/
export default defineConfig({
    server: {
        port: 5000,
        strictPort: true,
        host: true,
        origin: 'http://0.0.0.0:5000',
    },
    plugins: [react()],
});
