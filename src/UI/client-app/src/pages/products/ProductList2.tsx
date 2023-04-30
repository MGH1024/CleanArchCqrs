import * as React from 'react';
import Box from '@mui/material/Box';
import {
    DataGrid,
    GridColDef,
    GridValueGetterParams,
    GridToolbar,
} from '@mui/x-data-grid';
import Paper from '@mui/material/Paper';
import Stack from '@mui/material/Stack';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';

const columns: GridColDef[] = [
    {
        field: 'id',
        headerName: 'ID',
        minWidth: 160
    },
    {
        field: 'firstName',
        headerName: 'First name',
        minWidth: 200,
        editable: true,
    },
    {
        field: 'lastName',
        headerName: 'Last name',
        minWidth: 200,
        editable: true,
    },
    {
        field: 'age',
        headerName: 'Age',
        headerAlign: 'left',
        type: 'number',
        minWidth: 200,
        editable: true,
        align: 'left'
    },
    {
        field: 'fullName',
        headerName: 'Full name',
        description: 'This column has a value getter and is not sortable.',
        sortable: false,
        minWidth: 200,
        valueGetter: (params: GridValueGetterParams) =>
            `${params.row.firstName || ''} ${params.row.lastName || ''}`,
    },
    {
        field: "updateButton",
        headerName: "Actions",
        description: "Actions column.",
        sortable: false,
        minWidth: 200,
        renderCell: (params) => {
            return (
                <div>
                    <Stack spacing={2} direction="row">
                        <EditIcon
                            onClick={(e) => updateHandler(e, params.row)}
                            color="success"/>

                        <DeleteIcon
                            onClick={(e) => deleteHandler(e, params.row)}
                            color="error"/>
                    </Stack>
                </div>
            );
        }
    }
];

const rows = [
    {id: 1, lastName: 'Snow', firstName: 'Jon', age: 35},
    {id: 2, lastName: 'Lanni', firstName: 'jow', age: 42},
    {id: 3, lastName: 'Star', firstName: 'Jaime', age: 45},
    {id: 4, lastName: 'Stark', firstName: 'Aria', age: 16},
    {id: 5, lastName: 'Targaryen', firstName: 'david', age: null},
    {id: 6, lastName: 'Mela', firstName: null, age: 150},
    {id: 7, lastName: 'Clifford', firstName: 'Ferrara', age: 44},
    {id: 8, lastName: 'Frances', firstName: 'Rossini', age: 36},
    {id: 9, lastName: 'Roxie', firstName: 'Harvey', age: 65},
];
const deleteHandler = (e: any, row: any) => {
    e.stopPropagation();
    alert(row.id);
};

const updateHandler = (e: any, row: any) => {
    e.stopPropagation();
    alert(row.id);
};

export default function DataGridDemo() {
    return (
        <Paper sx={{width: '100%', overflow: 'hidden'}}>
            <Box sx={{height: 600, width: '100%'}}>
                <DataGrid
                    rows={rows}
                    columns={columns}
                    slots={{toolbar: GridToolbar}}
                    initialState={{
                        pagination: {
                            paginationModel: {
                                pageSize: 5,
                            },
                        },
                    }}
                    pageSizeOptions={[5]}
                    checkboxSelection
                    disableRowSelectionOnClick
                />
            </Box>
        </Paper>
    );
}