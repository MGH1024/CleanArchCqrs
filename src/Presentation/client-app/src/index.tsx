import React from 'react';
import App from '../src/App'
import ReactDOM from 'react-dom/client';
import {BrowserRouter} from 'react-router-dom';
import {DevSupport} from "@react-buddy/ide-toolbox";
import {ComponentPreviews, useInitial} from "./dev";


const root = ReactDOM.createRoot(
    document.getElementById('root') as HTMLElement
);
root.render(
    <React.StrictMode>
        <BrowserRouter>
            <DevSupport ComponentPreviews={ComponentPreviews}
                        useInitialHook={useInitial}
            >
                <App/>
            </DevSupport>
        </BrowserRouter>
    </React.StrictMode>
);