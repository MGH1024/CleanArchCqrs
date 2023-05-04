import * as React from 'react';
import Box from '@mui/material/Box';
import {
    DataGrid,
    GridColDef,
    GridToolbar,
} from '@mui/x-data-grid';
import Paper from '@mui/material/Paper';
import Stack from '@mui/material/Stack';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import Button from '@mui/material/Button';
import {useNavigate} from 'react-router-dom';
import {useEffect, useState} from "react";
import IProduct from "../../types/product/product";
import {GetProducts} from "../../services/productService";


export default function ProductList() {
    let navigate = useNavigate();
    useEffect(() => {
        fetchProducts();
    }, [])

    const fetchProducts = async () => {
        let productsList = await GetProducts();
        setProducts(productsList);
    }

    const [products, setProducts] = useState<IProduct[]>([]);

    const columns: GridColDef[] = [
        {
            field: 'Id',
            headerName: 'ID',
            minWidth: 10,
            type: 'number',
            align: 'center',
            headerAlign: 'left'
        },
        {
            field: 'Title',
            headerName: 'Title',
            headerAlign: 'left',
            type: 'string',
            minWidth: 100,
            editable: true,
            align: 'center'
        },
        {
            field: 'CategoryTitle',
            headerName: 'CategoryTitle',
            minWidth: 140,
            editable: true,
            type: 'string',
            align: 'center',
            headerAlign: 'left'
        },
        {
            field: 'Code',
            headerName: 'Code',
            minWidth: 40,
            editable: true,
            type: 'number',
            align: 'center',
            headerAlign: 'left'
        },
        {
            field: 'CreatedDate',
            headerName: 'CreatedDate',
            sortable: false,
            minWidth: 200,
            align: 'center',
            headerAlign: 'left'
        },
        {
            field: 'Description',
            headerName: 'Description',
            headerAlign: 'left',
            type: 'string',
            minWidth: 200,
            editable: true,
            align: 'center'
        },
        {
            field: 'Order',
            headerName: 'Order',
            headerAlign: 'left',
            type: 'number',
            minWidth: 40,
            editable: true,
            align: 'center'
        },
        {
            field: 'Quantity',
            headerName: 'Quantity',
            headerAlign: 'left',
            type: 'number',
            minWidth: 40,
            editable: true,
            align: 'center'
        },
        {
            field: "actions",
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
            },
        }
    ]

    const deleteHandler = (e: any, row: any) => {
        e.stopPropagation();
    };

    const updateHandler = (e: any, row: any) => {
        e.stopPropagation();
        navigate(`/products/${row.Id}`);
    };

    return (
        <>
            <Box height={12}/>
            <Button onClick={() => {
                navigate('/products/addProduct');
            }}>Add Product</Button>
            <Paper sx={{width: '100%', overflow: 'hidden'}}>
                <Box sx={{height: 600, width: '100%'}}>
                    <DataGrid
                        rows={products}
                        columns={columns}
                        getRowId={(row: any) => row.Id}
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
        </>
    );
}