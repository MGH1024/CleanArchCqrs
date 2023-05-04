import * as React from 'react';
import Snackbar from '@mui/material/Snackbar';
import {AppContext} from "../contexts/appContext";
import {useContext} from "react";
import MuiAlert, {AlertProps} from '@mui/material/Alert';


const Alert = React.forwardRef<HTMLDivElement, AlertProps>(function Alert(
    props,
    ref,
) {
    return <MuiAlert elevation={50} ref={ref} variant="filled" {...props} />;
});
export default function Toast() {
    const {showToast, setShowToast} = useContext(AppContext);
    return (

        <Snackbar open={showToast.show} autoHideDuration={1000} onClose={() => {
            setShowToast({show: false})
        }}>
            <Alert onClose={() => {
                setShowToast({show: false})
            }} severity={showToast.severity} sx={{width: '100%'}}>
                {showToast.message}
            </Alert>
        </Snackbar>
    )
}