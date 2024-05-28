import { Spinner } from "@fluentui/react-components";

interface LazyContentLoaderProps {
    status: 'idle' | 'loading' | 'succeed' | 'failed',
    children: React.ReactNode;
}

export const LazyContentLoader = (props: LazyContentLoaderProps) => {
    if (props.status === 'idle'){
        return(<Spinner />)
    }
    else if (props.status === 'loading'){
        return(<Spinner />)
    }
    else {
        return (
            <>
                {props.children}
            </>
        )
    }
}