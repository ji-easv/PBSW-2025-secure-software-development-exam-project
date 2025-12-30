import { useEffect, useState } from "react";
import "./App.css";
import TaskForm from "./components/TaskForm";
import TaskList from "./components/TaskList";
import type {
  CreateTaskItemDto,
  GetTaskItemDto,
  UpdateTaskItemDto,
} from "./domain/dto";

const API_URL = "http://localhost:5021/api/v1/tasks";

function App() {
  const [tasks, setTasks] = useState<GetTaskItemDto[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [newTask, setNewTask] = useState<CreateTaskItemDto>({
    title: "",
    description: undefined,
  });
  const [editTask, setEditTask] = useState<UpdateTaskItemDto | null>(null);

  // Fetch all tasks
  const fetchTasks = async () => {
    setLoading(true);
    setError(null);
    try {
      const res = await fetch(API_URL);
      if (!res.ok) throw new Error("Failed to fetch tasks");
      const data = await res.json();
      setTasks(data);
    } catch (e: any) {
      setError(e.message);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchTasks();
  }, []);

  // Create task
  const handleCreate = async (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);
    try {
      const res = await fetch(API_URL, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(newTask),
      });
      if (!res.ok) throw new Error("Failed to create task");
      setNewTask({ title: "", description: "" });
      fetchTasks();
    } catch (e: any) {
      setError(e.message);
    }
  };

  // Update task
  const handleUpdate = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!editTask) return;
    setError(null);
    try {
      const res = await fetch(API_URL, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(editTask),
      });
      if (!res.ok) throw new Error("Failed to update task");
      setEditTask(null);
      fetchTasks();
    } catch (e: any) {
      setError(e.message);
    }
  };

  // Delete task
  const handleDelete = async (id: string) => {
    setError(null);
    try {
      const res = await fetch(`${API_URL}/${id}`, { method: "DELETE" });
      if (!res.ok && res.status !== 204)
        throw new Error("Failed to delete task");
      fetchTasks();
    } catch (e: any) {
      setError(e.message);
    }
  };

  return (
    <div className="App">
      <h1>TODO App</h1>
      {error && <div style={{ color: "red", marginBottom: 12 }}>{error}</div>}
      <TaskForm
        value={editTask ?? newTask}
        onChange={(val) => {
          if (editTask) {
            setEditTask(val as UpdateTaskItemDto);
          } else {
            setNewTask(val as CreateTaskItemDto);
          }
        }}
        onSubmit={editTask ? handleUpdate : handleCreate}
        onCancel={editTask ? () => setEditTask(null) : undefined}
        isEdit={!!editTask}
      />
      {loading ? (
        <div>Loading...</div>
      ) : (
        <TaskList
          tasks={tasks}
          onEdit={(task) =>
            setEditTask({
              id: task.id,
              title: task.title,
              description: task.description ?? "",
              isCompleted: !!task.isCompleted,
            })
          }
          onDelete={handleDelete}
          onToggleComplete={async (task) => {
            setError(null);
            try {
              const updated = {
                id: task.id,
                title: task.title,
                description: task.description ?? "",
                isCompleted: !task.isCompleted,
              };
              const res = await fetch(API_URL, {
                method: "PUT",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(updated),
              });
              if (!res.ok) throw new Error("Failed to update task");
              fetchTasks();
            } catch (e: any) {
              setError(e.message);
            }
          }}
        />
      )}
    </div>
  );
}

export default App;
