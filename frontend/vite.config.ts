import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    proxy: {
      // secure: false → aceita o certificado self-signed do backend de dev (ASP.NET em https://localhost)
      "/tasks": { target: "https://localhost:7196", secure: false },
      "/auth": { target: "https://localhost:7196", secure: false },
    },
  },
});
