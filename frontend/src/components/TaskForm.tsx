import React from "react";
import type { CreateTaskItemDto, UpdateTaskItemDto } from "../domain/dto";
import "./TaskForm.css";

interface TaskFormProps {
  value: CreateTaskItemDto | UpdateTaskItemDto;
  onChange: (value: CreateTaskItemDto | UpdateTaskItemDto) => void;
  onSubmit: (e: React.FormEvent) => void;
  onCancel?: () => void;
  isEdit?: boolean;
}

const TaskForm: React.FC<TaskFormProps> = ({ value, onChange, onSubmit, onCancel, isEdit }) => (
  <form className="task-form" onSubmit={onSubmit}>
    <input
      type="text"
      placeholder="Title"
      value={value.title}
      onChange={e => onChange({ ...value, title: e.target.value })}
      required
    />
    <input
      type="text"
      placeholder="Description"
      value={value.description ?? ''}
      onChange={e => onChange({ ...value, description: e.target.value })}
    />
    <div className="form-actions">
      <button type="submit">{isEdit ? "Update" : "Add"}</button>
      {isEdit && onCancel && (
        <button type="button" onClick={onCancel} className="cancel">Cancel</button>
      )}
    </div>
  </form>
);

export default TaskForm;
