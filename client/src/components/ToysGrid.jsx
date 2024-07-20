import * as React from 'react';
import axios from 'axios'
import { useEffect, useState } from "react";
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import AddIcon from '@mui/icons-material/Add';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/DeleteOutlined';
import SaveIcon from '@mui/icons-material/Save';
import CancelIcon from '@mui/icons-material/Close';
import {
  GridRowModes,
  DataGrid,
  GridToolbarContainer,
  GridActionsCellItem,
  GridRowEditStopReasons,
} from '@mui/x-data-grid';
import {
  randomCreatedDate,
  randomTraderName,
  randomId,
  randomArrayItem,
} from '@mui/x-data-grid-generator';

const basicProductsUrl='https://localhost:44381/api/products'

function EditToolbar(props) {

  const { setRows, setRowModesModel } = props;

  const handleClick = async() => {
    const id = randomId();
    setRows((oldRows) => [...oldRows, {
      id: '', name: '', title: '', description: '', image: '',
      count: '', price: '', makat: ''
    }]);

    setRowModesModel((oldModel) => ({
      ...oldModel,
      [id]: { mode: GridRowModes.Edit, fieldToFocus: 'name' },
    }));

    await axios.post(`${basicProductsUrl}/`, {
      name: '', title: '', description: '', picture: '',
      count: '', price: '', makat: ''
    })
  }
  return (
    <GridToolbarContainer>
      <Button variant="contained" color="success" onClick={handleClick}>+</Button>
    </GridToolbarContainer>
  );
}

export default function ToysGrid() {

  const [rows, setRows] = React.useState([]);
  const [rowModesModel, setRowModesModel] = React.useState({})

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get(`${basicProductsUrl}/productsOrdersCount`);
        const data = response.data;
        console.log(data);
        const dataWithRows = data.map(item => ({
          ...item.product,
          picture: `data:image/jpeg;base64,${item.product.picture}`,
          orderQuantity: item.ordersCount
        }));
          setRows(dataWithRows);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    fetchData();
  }, []);
  
  const handleRowEditStop = (params, event) => {
    if (params.reason === GridRowEditStopReasons.rowFocusOut) {
      event.defaultMuiPrevented = true;
    }
  };

  const handleEditClick = (id) => () => {
    setRowModesModel({ ...rowModesModel, [id]: { mode: GridRowModes.Edit } });
  };

  const handleSaveClick = (id) => () => {
    setRowModesModel({ ...rowModesModel, [id]: { mode: GridRowModes.View } });
  };

  const handleDeleteClick = (id) =>async () => {
    const confirmed = window.confirm('מאשר מחיקה?');
    if (confirmed) {
      setRows(rows.filter((row) => row.id !== id));
      try {
        await axios.delete(`${basicProductsUrl}/${id}`);
        setRows(rows.filter((row) => row.id !== id));
        console.log("Item deleted successfully");
      } catch (error) {
        console.error("Error deleting item:", error);
      }
    } else {
      console.log("Deletion canceled");
    }
  }

  const handleCancelClick = (id) => () => {
    setRowModesModel({
      ...rowModesModel,
      [id]: { mode: GridRowModes.View, ignoreModifications: true },
    });

    const editedRow = rows.find((row) => row.id === id);
    if (editedRow.isNew) {
      setRows(rows.filter((row) => row.id !== id));
    }
  };

  const processRowUpdate = async(newRow) => {
    const updatedRow = { ...newRow, isNew: false };
    setRows(rows.map((row) => (row.id === newRow.id ? updatedRow : row)));
   await axios.put(`${basicProductsUrl}/${newRow.id}`, newRow);
    return updatedRow;
  };

  const handleRowModesModelChange = (newRowModesModel) => {
    setRowModesModel(newRowModesModel);
  };

  const columns = [
    { field: 'makat', headerName: 'מק"ט', type: 'number', width: 180, editable: true },
    {
      field: 'title',
      headerName: 'כותרת',
      width: 180,
      editable: true,
      renderCell: (params) => (params.value.length > 20 ? `${params.value.substring(0, 20)}...` : params.value),

    },
    {
      field: 'description',
      headerName: 'תיאור',
      width: 220,
      editable: true,
      renderCell: (params) => (params.value.length > 100 ? `${params.value.substring(0, 100)}...` : params.value),
    },
    {
      field: 'price',
      headerName: 'מחיר',
      type: 'number',
      width: 120,
      editable: true,
    },
        {
      field: 'orderQuantity',
      headerName: 'כמות ההזמנות',
      type: 'number',
      width: 180,
      editable: true,
    },
    {
      field: 'picture',
      headerName: 'תמונה',
      width: 120,
      editable: true,
      renderCell: (params) => <img src={params.value} style={{ width: '50px', height: '50px' }} alt="Toy" />,
    },
    {
      field: 'actions',
      type: 'actions',
      headerName: 'Actions',
      width: 100,
      cellClassName: 'actions',
      getActions: ({ id }) => {
        const isInEditMode = rowModesModel[id]?.mode === GridRowModes.Edit;

        if (isInEditMode) {
          return [
            <GridActionsCellItem
              icon={<SaveIcon />}
              label="Save"
              sx={{
                color: 'primary.main',
              }}
              onClick={handleSaveClick(id)}
            />,
            <GridActionsCellItem
              icon={<CancelIcon />}
              label="Cancel"
              className="textPrimary"
              onClick={handleCancelClick(id)}
              color="inherit"
            />,
          ];
        }

        return [
          <GridActionsCellItem
            icon={<EditIcon />}
            label="Edit"
            className="textPrimary"
            onClick={handleEditClick(id)}
            color="inherit"
            sx={{ p: 1, backgroundColor: 'green' }}
          />,
          <GridActionsCellItem
            icon={<DeleteIcon />}
            label="Delete"
            onClick={handleDeleteClick(id)}
            color="inherit"
            sx={{ p: 1, backgroundColor: 'red' }}
          />,
        ];
      },
    },
  ];

  return (
    <>
    <h1>ניהול צעצועים</h1>
    <Box
      sx={{
        height: 500,
        width: '100%',
        '& .actions': {
          color: 'text.secondary',
        },
        '& .textPrimary': {
          color: 'text.primary',
        },
      }}
    >
      <DataGrid
      key="id"
        rows={rows}
        columns={columns}
        editMode="row"
        rowModesModel={rowModesModel}
        onRowModesModelChange={handleRowModesModelChange}
        onRowEditStop={handleRowEditStop}
        processRowUpdate={processRowUpdate}
        slots={{
          toolbar: EditToolbar,
        }}
        slotProps={{
          toolbar: { setRows, setRowModesModel },
        }}
        sx={{
          '& .MuiDataGrid-cell': {
            borderRight: '1px solid #ccc',
            borderBottom: '1px solid #ccc',
          },
        }}
      />
     
    </Box>
    {EditToolbar}
    </>
  );
}