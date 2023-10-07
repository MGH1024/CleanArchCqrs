import * as React from 'react';
import Box from '@mui/material/Box';
import {useContext, useEffect, useState} from "react";
import Button from '@mui/material/Button';
import Select from '@mui/material/Select';
import {useNavigate} from "react-router-dom";
import TextField from '@mui/material/TextField';
import Container from '@mui/material/Container';
import ICategory from "../../types/category/categoryList";
import Typography from '@mui/material/Typography';
import InputLabel from '@mui/material/InputLabel';
import FormControl from '@mui/material/FormControl';
import CssBaseline from '@mui/material/CssBaseline';
import {CreateProduct} from "../../services/productService";
import {GetCategories} from "../../services/categoryServices";
import {createTheme, ThemeProvider} from '@mui/material/styles';
import {AppContext} from "../../contexts/appContext";
import Navbar from "../../components/navbar";
import Sidenav from "../../components/sidenav";

const theme = createTheme();
export default function AddProduct() {
    const {showToast, setShowToast} = useContext(AppContext);


    useEffect(() => {
        fetchCategories();
    }, [])

    const fetchCategories = async () => {
        let categories = await GetCategories();
        setCategories(categories);
    }


    let navigate = useNavigate();
    const [code, setCode] = useState(0);
    const [title, setTitle] = useState("");
    const [quantity, setQuantity] = useState(0);
    const [description, setDescription] = useState("");
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

            const result = await CreateProduct({
                code,
                title,
                quantity,
                categoryId,
                description,
            });
            if (result.Success) {
                setShowToast({message: 'New product created', show: true, severity: 'success'})
                navigate(`/products`);
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
                                    marginTop: 6,
                                    display: 'flex',
                                    flexDirection: 'column',
                                    alignItems: 'left',
                                }}
                            >
                                <Typography component="h1" variant="h5">
                                    Add Product
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
                                        onChange={e => setDescription(e.target.value)}
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