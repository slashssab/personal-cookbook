import { Button, DialogActions, DialogBody, DialogContent, Option, DialogSurface, DialogTitle, Dropdown, makeStyles, OptionOnSelectData, SelectionEvents, shorthands, useId, InputOnChangeData } from "@fluentui/react-components";
import { Step } from "../Models/Step";
import { ChangeEvent, useState } from "react";
import { TextInput } from "./TextInput";
import { StepType } from "../Models/Enums/StepType";

const useStyles = makeStyles({
    root: {
        // Stack the label above the field with a gap
        display: "grid",
        gridTemplateRows: "repeat(1fr)",
        justifyItems: "start",
        ...shorthands.gap("2px"),
        maxWidth: "400px",
    },
});

interface AddStepDialogProperties {
    openDialog(open: boolean): void;
    addStep(step: Step): void;
}

const getStepTypeNames = () => {
    const stepTypeNames: string[] = [];
    for (var enumMember in StepType) {
        var isValueProperty = Number(enumMember) >= 0
        if (isValueProperty) {
            stepTypeNames.push(StepType[enumMember]);
        }
    }
    return stepTypeNames;
}

export const AddStepDialog = (dialogProps: AddStepDialogProperties) => {
    const styles = useStyles();
    const dropdownId = useId("dropdown-step-type");
    const [step, setStep] = useState<Step>({ id: 0 } as Step);
    const stepTypeNames = getStepTypeNames()

    const handleStepSelect = (event: SelectionEvents, data: OptionOnSelectData) => {
        const selectedStepTypeId = stepTypeNames.indexOf(data.optionText ?? '');
        setStep({ ...step, type: selectedStepTypeId });
    }

    const closeDialog = () => {
        dialogProps.openDialog(false);
    }

    const addStep = () => {
        if (step.type === undefined) {
            alert("Please select type.")
        }
        else if (step.content === undefined) {
            alert("Please provide content.")
        }
        else {
            dialogProps.addStep(step);
        }
    }

    const handleContentChanged = (event: ChangeEvent<HTMLInputElement>, data: InputOnChangeData) => {
        setStep({ ...step, content: data.value });
    }

    return (<DialogSurface>
        <DialogBody>
            <DialogTitle>Add step</DialogTitle>
            <DialogContent>
                <div className={styles.root}>
                    <label id={dropdownId}>Select product</label>
                    <span>Selected {step?.type}</span>
                    <Dropdown
                        aria-labelledby={dropdownId}
                        placeholder="Step type"
                        {...dialogProps}
                        onOptionSelect={handleStepSelect}
                    >
                        {stepTypeNames.map((stepName, index) => (
                            <Option key={index}>
                                {stepName}
                            </Option>
                        ))}
                    </Dropdown>
                </div>
                <TextInput text={"Content"} onChange={handleContentChanged} />
            </DialogContent>
            <DialogActions>
                <Button onClick={closeDialog} appearance="secondary">Close</Button>
                <Button onClick={addStep} appearance="primary">Add Step</Button>
            </DialogActions>
        </DialogBody>
    </DialogSurface>)
}