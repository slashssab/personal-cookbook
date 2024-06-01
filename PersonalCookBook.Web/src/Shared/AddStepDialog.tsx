import { Step } from "../Models/Step";

interface AddStepDialogProperties {
    openDialog(open: boolean): void;
    addStep(step: Step): void;
}

export const AddStepDialog = (dialogProps: AddStepDialogProperties) => {

}