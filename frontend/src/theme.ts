import { createTheme } from '@mui/material/styles'

// Tema central da aplicação. Ajuste cores, tipografia e densidade aqui.
const theme = createTheme({
  palette: {
    mode: 'light',
    primary: { main: '#1976d2' },
    secondary: { main: '#9c27b0' },
  },
  shape: { borderRadius: 8 },
})

export default theme
