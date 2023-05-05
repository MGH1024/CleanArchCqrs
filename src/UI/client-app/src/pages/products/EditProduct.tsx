import * as React from 'react';
import Box from '@mui/material/Box';
import {useContext, useEffect, useState} from "react";
import Button from '@mui/material/Button';
import Select from '@mui/material/Select';
import {useNavigate, useParams} from "react-router-dom";
import TextField from '@mui/material/TextField';
import Container from '@mui/material/Container';
import ICategory from "../../types/category/categoryList";
import Typography from '@mui/material/Typography';
import InputLabel from '@mui/material/InputLabel';
import FormControl from '@mui/material/FormControl';
import CssBaseline from '@mui/material/CssBaseline';
import {GetProductById, UpdateProduct} from "../../services/productService";
import {GetCategories} from "../../services/categoryServices";
import {createTheme, ThemeProvider} from '@mui/material/styles';
import Navbar from "../../components/navbar";
import Sidenav from "../../components/sidenav";
import {AppContext} from "../../contexts/appContext";

const theme = createTheme();
export default function EditProduct() {
    const {id} = useParams<{ id?: string }>();
    const {showToast, setShowToast} = useContext(AppContext);
    useEffect(() => {
        fetchCategories();
        fetchProduct(id);

    }, [])

    const fetchCategories = async (): Promise<void> => {
        let categories = await GetCategories();
        setCategories(categories);
    }

    const fetchProduct = async (id: string | undefined): Promise<void> => {

        let productObj = await GetProductById({
            id: id
        });
        setTitle(productObj.Title);
        setQuantity(productObj.Quantity);
        setCode(productObj.Code);
        setCategoryId(productObj.CategoryId);
        setDescription(productObj.Description);
    }


    let navigate = useNavigate();
    const [code, setCode] = useState(0);
    const [title, setTitle] = useState("");
    const [quantity, setQuantity] = useState<number>(0);
    const [description, setDescription] = useState<string | undefined>("");
    const [categoryId, setCategoryId] = useState<number>(1);

    const [codeError, setCodeError] = useState<boolean>(false);
    const [titleError, setTitleError] = useState<boolean>(false);
    const [quantityError, setQuantityError] = useState<boolean>(false);
    const [categories, setCategories] = useState<ICategory[]>([]);
    const [categoryIdError, setCategoryIdError] = useState<boolean>(false);

    const handleCategoryChange = (event: any) => {
        let value = parseInt(event.target.value);
        setCategoryId(value);
        if (value)
            setCategoryIdError(false);
    };
    const handleTitleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        let value = event.target.value;
        setTitle(value);
        if (value)
            setTitleError(false);
    }
    const handleQuantityChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        let value = parseInt(event.currentTarget.value);
        setQuantity(value);
        if (value)
            setQuantityError(false);
    }
    const handleCodeChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        let value = parseInt(event.currentTarget.value);
        setCode(value);
        if (value)
            setCodeError(false);
    }
    
    const handleDescriptionChange = (event:React.ChangeEvent<HTMLInputElement>) =>{
        setDescription(event.target.value)  
    } 

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        if (!code)
            setCodeError(true);
        if (!title)
            setTitleError(true);
        if (!quantity)
            setQuantityError(true);
        if (!categoryId)
            setCategoryIdError(true);


        if (title && code && quantity && categoryId) {
            let result = await UpdateProduct({
                id,
                code,
                title,
                quantity,
                categoryId,
                description,
            });
            if (result.Success) {
                setShowToast({message: 'product updated', show: true, severity: 'success'})
                navigate('/products');
            }
        }
    };

    return (
        <>
            <Navbar/>
            <Box height={30}/>
            <Box sx={{display: "flex"}}>
                <Sidenav/>
                <Box component="main" >
                    <ThemeProvider theme={theme}>
                        <Container component="main" maxWidth="md">
                            <CssBaseline/>
                            <Box
                                sx={{
                                    marginTop: 8,
                                    display: 'flex',
                                    flexDirection: 'column',
                                    alignItems: 'left',
                                }}
                            >
                                <Typography component="h1" variant="h5">
                                    Edit Product
                                </Typography>
                                <Box component="form" onSubmit={handleSubmit} noValidate sx={{mt: 1}}>
                                    <TextField
                                        margin="normal"
                                        required
                                        fullWidth
                                        id="title"
                                        label="Title"
                                        name="title"
                                        autoComplete="Title"
                                        autoFocus
                                        value={title}
                                        error={titleError}
                                        onChange={handleTitleChange}
                                    />
                                    <TextField
                                        margin="normal"
                                        required
                                        fullWidth
                                        id="quantity"
                                        label="Quantity"
                                        type="number"
                                        InputLabelProps={{
                                            shrink: true,
                                        }}
                                        value={quantity}
                                        onChange={handleQuantityChange}
                                        error={quantityError}
                                    />

                                    <TextField
                                        margin="normal"
                                        required
                                        fullWidth
                                        id="code"
                                        label="Code"
                                        type="number"
                                        InputLabelProps={{
                                            shrink: true,
                                        }}
                                        value={code}
                                        onChange={handleCodeChange}
                                        error={codeError}
                                    />

                                    <FormControl fullWidth>
                                        <InputLabel shrink htmlFor="select-multiple-native">
                                            Category
                                        </InputLabel>
                                        <Select
                                            native
                                            value={categoryId}
                                            onChange={handleCategoryChange}
                                            error={categoryIdError}
                                            label="Native"
                                            inputProps={{
                                                id: 'select-multiple-native',
                                            }}
                                        >
                                            {categories.map((cat) => (
                                                <option key={cat.Title} value={cat.Id}>
                                                    {cat.Title}
                                                </option>
                                            ))}
                                        </Select>
                                    </FormControl>


                                    <TextField
                                        margin="normal"
                                        required
                                        fullWidth
                                        id="description"
                                        label="Description"
                                        name="description"
                                        autoComplete="description"
                                        autoFocus
                                        value={description}
                                        onChange={handleDescriptionChange}
                                    />

                                    <Button
                                        type="submit"
                                        fullWidth
                                        variant="contained"
                                        sx={{mt: 3, mb: 2}}
                                    >
                                        submit
                                    </Button>
                                </Box>
                            </Box>
                        </Container>
                    </ThemeProvider>
                </Box>
            </Box>
        </>
    );
}