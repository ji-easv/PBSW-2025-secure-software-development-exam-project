import React from "react";
import type { GetTaskItemDto } from "../domain/dto";
import "./TaskList.css";

interface TaskListProps {
  tasks: GetTaskItemDto[];
  onEdit: (task: GetTaskItemDto) => void;
  onDelete: (id: string) => void;
  onToggleComplete: (task: GetTaskItemDto) => void;
}

const TaskList: React.FC<TaskListProps> = ({
  tasks,
  onEdit,
  onDelete,
  onToggleComplete,
}) => (
  <ul className="task-list">
    {tasks.map((task) => (
      <li
        key={task.id}
        className={`task-item${task.isCompleted ? " completed" : ""}`}
      >
        <div className="task-main">
          <input
            type="checkbox"
            checked={!!task.isCompleted}
            onChange={() => onToggleComplete(task)}
          />
          <div className="task-info">
            <span className="task-title">{task.title}</span>
            {task.description && (
              <span className="task-desc">{task.description}</span>
            )}
          </div>
        </div>
        <div className="task-actions">
          <button onClick={() => onEdit(task)}>Edit</button>
          <button className="delete" onClick={() => onDelete(task.id)}>
            Delete
          </button>
        </div>
      </li>
    ))}
  </ul>
);

export default TaskList;
