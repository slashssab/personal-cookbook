import { StepType } from "./Enums/StepType";

export interface Step {
    id: number;
    order: number;
    content: string;
    type: StepType;
}