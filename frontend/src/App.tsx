import AppBar from '@mui/material/AppBar'
import Toolbar from '@mui/material/Toolbar'
import Typography from '@mui/material/Typography'
import Container from '@mui/material/Container'
import Box from '@mui/material/Box'
import Paper from '@mui/material/Paper'
import TaskAltIcon from '@mui/icons-material/TaskAlt'
import ListTasks from './components/ListTasks'

function App() {
  return (
    <Box sx={{ display: 'flex', flexDirection: 'column', minHeight: '100vh' }}>
      <AppBar position="static">
        <Toolbar>
          <TaskAltIcon sx={{ mr: 1 }} />
          <Typography variant="h6" component="div">
            Tasks
          </Typography>
        </Toolbar>
      </AppBar>

      <Container component="main" maxWidth="md" sx={{ py: 4, flexGrow: 1 }}>
        <Paper sx={{ p: 4, textAlign: 'center' }}>
          <Typography variant="h4" gutterBottom>
            Frontend pronto 🎉
          </Typography>
          <Typography color="text.secondary">
            Esqueleto React + TypeScript + Material UI configurado. Comece a
            construir editando <code>src/App.tsx</code>.
            <ListTasks />
          </Typography>
        </Paper>
      </Container>
    </Box>
  )
}

export default App
