export type GetTaskItemDto = {
    id: string;
    title: string;
    description?: string | null;
    isCompleted?: boolean;
};

export type CreateTaskItemDto = {
    title: string;
    description?: string | null;
};

export type UpdateTaskItemDto = {
    id: string;
    title: string;
    description?: string | null;
    isCompleted: boolean;
};