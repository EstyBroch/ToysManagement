import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import ToysGrid from './ToysGrid';

const basicUsersUrl='https://localhost:44381/api/users'

function Copyright(props) {

  return (
    <Typography variant="body2" color="text.secondary" align="center" {...props}>
      {'Copyright © '}
      <Link color="inherit" href="https://mui.com/">
        Your Website
      </Link>{' '}
      {new Date().getFullYear()}
      {'.'}
    </Typography>
  );
}

const defaultTheme = createTheme();

export default function Login() {
  const navigate = useNavigate();

  const fetchUserFromDatabase = async (password, name) => {
    debugger
    axios.get(`${basicUsersUrl}/GetByPassword/${password}`)
      .than((response) => {
        console.log(".than")
        const userData = response.data;
        if (userData && userData.name == name && userData.role === 1) {
          console.log("User is a manager.");
          const localPassword = localStorage.getItem('password')
          if (localPassword == undefined || localPassword == "")
            localStorage.setItem('password', password);
          const localName = localStorage.getItem('name')
          if (localName == undefined || localName == "")
            localStorage.setItem('name', name);
          navigate('/toysGrid')
        }
        else{
          console.log("not exit or not a manager")
        }
      })


  }

  const handleSubmit = (event) => {
    console.log("submit")
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    const name = data.get('name');
    const password = data.get('password');
    fetchUserFromDatabase(password, name)


  }


  return (
    <ThemeProvider theme={defaultTheme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Sign in
          </Typography>
          <Box component="form" noValidate onSubmit={handleSubmit} sx={{ mt: 3 }}>
            <Grid container spacing={2}>

              <Grid item xs={12} >
                <TextField
                  required
                  fullWidth
                  id="name"
                  label="name"
                  name="name"
                  autoComplete="family-name"
                />
              </Grid>

              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  name="password"
                  label="Password"
                  type="password"
                  id="password"
                  autoComplete="new-password"
                />
              </Grid>

            </Grid>
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Sign in
            </Button>

          </Box>
        </Box>

      </Container>
    </ThemeProvider>
  );
}
