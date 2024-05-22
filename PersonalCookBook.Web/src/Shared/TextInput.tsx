import { Input, InputProps, Label, makeStyles, shorthands } from "@fluentui/react-components";

const useStyles = makeStyles({
    root: {
        // Stack the label above the field
        display: 'flex',
        flexDirection: 'column',
        // Use 2px gap below the label (per the design system)
        ...shorthands.gap('2px'),
        // Prevent the example from taking the full width of the page (optional)
        maxWidth: '400px',
    },
});

interface ITextInput extends InputProps {
    text: string | null;
}

export const TextInput = (inputProps: ITextInput) => {
    const styles = useStyles();

    return (
        <div className={styles.root}>
            <Label htmlFor={inputProps.id} size={inputProps.size} disabled={inputProps.disabled}>
                {inputProps.text}
            </Label>
            <Input type="text" id={inputProps.id} {...inputProps} />
        </div>
    );
};