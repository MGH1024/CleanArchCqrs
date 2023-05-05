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
import {GetProducts, DeleteProduct} from "../../services/productService";
import {AppContext} from "../../contexts/appContext";
import {useContext} from 'react';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';


export default function ProductList() {
    const {showToast, setShowToast} = useContext(AppContext);
    const [openDialog, setOpenDialog] = React.useState(false);
    const [productId, setProductId] = useState<number>(0);

    let navigate = useNavigate();
    useEffect(() => {
        fetchProducts();
    }, [])

    const fetchProducts = async () => {
        let productList = await GetProducts();
        setProducts(productList);
    }

    const [products, setProducts] = useState<IProduct[]>([]);

    const columns: GridColDef[] = [
        {
            field: 'Id',
            headerName: 'ID',
            minWidth: 10,
            type: 'number',
            align: 'center',
            headerAlign: 'center'
        },
        {
            field: 'Title',
            headerName: 'Title',
            headerAlign: 'center',
            type: 'string',
            minWidth: 150,
            editable: true,
            align: 'center'
        },
        {
            field: 'CategoryTitle',
            headerName: 'CategoryTitle',
            minWidth: 150,
            editable: true,
            type: 'string',
            align: 'center',
            headerAlign: 'center'
        },
        {
            field: 'Code',
            headerName: 'Code',
            minWidth: 40,
            editable: true,
            type: 'number',
            align: 'center',
            headerAlign: 'center'
        },
        {
            field: 'CreatedDate',
            headerName: 'CreatedDate',
            sortable: false,
            minWidth: 250,
            align: 'center',
            headerAlign: 'center'
        },
        {
            field: 'Description',
            headerName: 'Description',
            headerAlign: 'center',
            type: 'string',
            minWidth: 250,
            editable: true,
            align: 'center'
        },
        {
            field: 'Quantity',
            headerName: 'Quantity',
            headerAlign: 'center',
            type: 'number',
            minWidth: 60,
            editable: true,
            align: 'center'
        },
        {
            field: "actions",
            headerName: "Actions",
            description: "Actions column.",
            sortable: false,
            minWidth: 250,
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


    const updateHandler = (e: React.MouseEvent<SVGSVGElement, MouseEvent>, row: any) => {
        e.stopPropagation();
        navigate(`/products/${row.Id}`);
    };


    const deleteHandler = (e: React.MouseEvent<SVGSVGElement>, row: any) => {
        setProductId(row.Id);
        setOpenDialog(true);
    };

    const handleDelete_Main = async () => {
        setOpenDialog(false);
        const result = await DeleteProduct({
            Id: productId
        });
        if (result.Success) {
            setShowToast({message: 'product deleted', show: true, severity: 'success'})
            setProducts(products.filter(p => p.Id !== productId));
            navigate('/products');
        }
    };

    const handleDialogClose = () => {
        setOpenDialog(false);
    };


    return (
        <>
            <Box height={12}/>
            <Button variant="contained" onClick={() => {
                navigate('/products/addProduct');
            }}>Create New Product</Button>
            <Box height={20}/>
            <Paper sx={{width: '100%', overflow: 'hidden'}}>
                <Box sx={{height: 400, width: '100%'}}>
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

            <Dialog
                open={openDialog}
                onClose={handleDialogClose}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description"
            >
                <DialogTitle id="alert-dialog-title">
                    {"Are you sure about delete this product?"}
                </DialogTitle>
                <DialogContent>
                    <DialogContentText id="alert-dialog-description">
                        please confirm or cancel!
                    </DialogContentText>
                </DialogContent>
                <DialogActions>
                    <Button color='error' variant="contained" onClick={handleDelete_Main}>Delete</Button>
                    <Button color='primary' variant="contained" onClick={handleDialogClose}>Cancel</Button>
                </DialogActions>
            </Dialog>
        </>
    );
}