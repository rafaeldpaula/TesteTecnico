import { useEffect, useState } from 'react'
import { getTasks } from '../api/task/task'
import type { TaskItem } from '../api/task/types'

function ListTasks() {
  const [tasks, setTasks] = useState<TaskItem[]>([])
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState(null)

  useEffect(() => {
    let cancelled = false

    setLoading(true);
    setError(null);

    getTasks()
      .then(task => {
        setTasks(task)
      })
      .catch(err => {
        console.log(`Erro detectado: {err}`)
        setError(err)
        setTasks([])
      })
      .finally(() => {
        if (!cancelled)
          setLoading(false)          
      })

    return () => {
      cancelled = true;
    }
  }, [tasks])

  return (
    <table>
      <thead>
        <tr>
          <th>Título</th>
          <th>Descrição</th>
          <th>Status</th>
          <th>Ações</th>
        </tr>
      </thead>
      <tbody>
        {tasks.map(item => (
          <tr key={item.id}>
            <td>{item.title}</td>
            <td>{item.description}</td>
            <td>{item.status}</td>
            <td></td>
          </tr>
        ))}
      </tbody>
    </table>
  )
}

export default ListTasks