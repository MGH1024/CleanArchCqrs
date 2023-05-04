import {AlertColor} from '@mui/material';

export default interface IToast {
    message: string,
    show: boolean,
    severity: AlertColor | undefined
}